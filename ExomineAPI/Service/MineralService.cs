using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class MineralService
    {
        public IEnumerable<MineralDTO> GetAllMinerals()
        {
            return MineralData.Minerals.Select(min => new MineralDTO
            {
                Id = min.Id,
                Name = min.Name,
            });
        }

        public MineralDTO GetMineralById(int id)
        {
            var mineral = MineralData.Minerals.FirstOrDefault(min => min.Id == id);
            if (mineral == null)
                return null;

            return new MineralDTO { Id = mineral.Id, Name = mineral.Name };
        }

        public IEnumerable<MineralDTO> GetMineralsByGovernorId(int governorId)
        {
            // Find the governor; if not found, return an empty list
            var governor = GovernorData.Governors.FirstOrDefault(gov => gov.Id == governorId);
            if (governor == null)
            {
                return Enumerable.Empty<MineralDTO>();
            }

            // Find the colony; if not found, return an empty list
            var colony = ColonyData.Colonies.FirstOrDefault(col => col.Id == governor.ColonyId);
            if (colony == null)
            {
                return Enumerable.Empty<MineralDTO>();
            }

            // Filter colony minerals by the colony ID
            var colonyMinerals = ColonyMineralData.ColonyMinerals.Where(colMin =>
                colMin.ColonyId == colony.Id
            );

            // Join minerals with colony minerals to include quantity
            var mineralsWithQuantities =
                from colMin in colonyMinerals
                join min in MineralData.Minerals on colMin.MineralId equals min.Id
                select new MineralDTO
                {
                    Id = min.Id,
                    Name = min.Name,
                    Quantity = colMin.Quantity, // Populate Quantity from the join table
                };

            return mineralsWithQuantities;
        }

        public IEnumerable<MineralDTO> GetMineralsByFacilityId(int facilityId)
        {
            // Filter FacilityMinerals by the given FacilityId
            var facilityMinerals = FacilityMineralData.FacilityMinerals.Where(fm =>
                fm.FacilityId == facilityId
            );

            // Join minerals with facility minerals to include quantity
            var mineralsWithQuantities =
                from fm in facilityMinerals
                join min in MineralData.Minerals on fm.MineralId equals min.Id
                select new MineralDTO
                {
                    Id = min.Id,
                    Name = min.Name,
                    Quantity = fm.Quantity, // Populate Quantity from the join table
                };

            return mineralsWithQuantities;
        }
    }
}

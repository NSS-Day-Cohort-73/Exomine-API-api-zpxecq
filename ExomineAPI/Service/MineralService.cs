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

            // Find matching minerals
            var minerals = MineralData.Minerals.Where(min =>
                colonyMinerals.Any(colMin => colMin.MineralId == min.Id)
            );

            // Project to DTOs
            return minerals.Select(min => new MineralDTO { Id = min.Id, Name = min.Name });
        }

        public IEnumerable<MineralDTO> GetMineralsByFacilityId(int facilityId)
        {
            // Filter FacilityMinerals by the given FacilityId
            var facilityMinerals = FacilityMineralData.FacilityMinerals.Where(fm =>
                fm.FacilityId == facilityId
            );

            // Find matching minerals based on FacilityMinerals
            var minerals = MineralData.Minerals.Where(min =>
                facilityMinerals.Any(fm => fm.MineralId == min.Id)
            );

            // Map the minerals to MineralDTO
            return minerals.Select(min => new MineralDTO { Id = min.Id, Name = min.Name });
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class FacilityMineralService
    {
        public IEnumerable<FacilityMineralDTO> GetAllFacilityMinerals()
        {
            return FacilityMineralData.FacilityMinerals.Select(fm => new FacilityMineralDTO
            {
                Id = fm.Id,
                FacilityId = fm.FacilityId,
                MineralId = fm.MineralId,
                Quantity = fm.Quantity,
            });
        }

        public FacilityMineralDTO GetFacilityMineralById(int id)
        {
            var facilityMineral = FacilityMineralData.FacilityMinerals.FirstOrDefault(fm =>
                fm.Id == id
            );
            if (facilityMineral == null)
                return null;

            return new FacilityMineralDTO
            {
                Id = facilityMineral.Id,
                FacilityId = facilityMineral.FacilityId,
                MineralId = facilityMineral.MineralId,
                Quantity = facilityMineral.Quantity,
            };
        }
    }
}

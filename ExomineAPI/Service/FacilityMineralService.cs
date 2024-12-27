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

        public FacilityMineralDTO UpdateFacilityMineral(
            int id,
            FacilityMineralDTO updatedFacilityMineral
        )
        {
            var facilityMineral = FacilityMineralData.FacilityMinerals.FirstOrDefault(fm =>
                fm.Id == id
            );

            if (facilityMineral == null)
            {
                return null; // Return null if the facility mineral with the given id is not found
            }

            // Update the properties
            facilityMineral.Quantity = updatedFacilityMineral.Quantity;

            // Return the updated DTO
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

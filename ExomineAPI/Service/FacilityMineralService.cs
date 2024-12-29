using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class FacilityMineralService
    {
        public IEnumerable<FacilityMineralDTO> GetAllFacilityMinerals(
            bool expandFacility = false,
            bool expandMineral = false,
            int? facilityId = null
        )
        {
            var query = FacilityMineralData.FacilityMinerals.AsEnumerable();

            // Filter by facilityId if provided
            if (facilityId.HasValue)
            {
                query = query.Where(fm => fm.FacilityId == facilityId.Value);
            }

            return query.Select(fm =>
            {
                var facilityMineralDto = new FacilityMineralDTO
                {
                    Id = fm.Id,
                    FacilityId = fm.FacilityId,
                    MineralId = fm.MineralId,
                    Quantity = fm.Quantity,
                };

                // Expand Facility if requested
                if (expandFacility)
                {
                    var facility = FacilityData.Facilities.FirstOrDefault(f =>
                        f.Id == fm.FacilityId
                    );
                    if (facility != null)
                    {
                        facilityMineralDto.Facility = new FacilityDTO
                        {
                            Id = facility.Id,
                            Name = facility.Name,
                            Active = facility.Active,
                        };
                    }
                }

                // Expand Mineral if requested
                if (expandMineral)
                {
                    var mineral = MineralData.Minerals.FirstOrDefault(m => m.Id == fm.MineralId);
                    if (mineral != null)
                    {
                        facilityMineralDto.Mineral = new MineralDTO
                        {
                            Id = mineral.Id,
                            Name = mineral.Name,
                        };
                    }
                }

                return facilityMineralDto;
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

        public FacilityMineralDTO CreateFacilityMineral(FacilityMineralDTO newFacilityMineral)
        {
            // Generate a new ID
            var newId = FacilityMineralData.FacilityMinerals.Max(fm => fm.Id) + 1;

            // Create the new FacilityMineral
            var facilityMineral = new FacilityMineral
            {
                Id = newId,
                FacilityId = newFacilityMineral.FacilityId,
                MineralId = newFacilityMineral.MineralId,
                Quantity = newFacilityMineral.Quantity,
            };

            // Update the database
            FacilityMineralData.FacilityMinerals.Add(facilityMineral);

            // Return the new DTO
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

using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class FacilityService
    {
        public IEnumerable<FacilityDTO> GetAllFacilities()
        {
            return FacilityData.Facilities.Select(fac => new FacilityDTO
            {
                Id = fac.Id,
                Name = fac.Name,
                Active = fac.Active,
            });
        }

        public FacilityDTO GetFacilityById(int id)
        {
            var facility = FacilityData.Facilities.FirstOrDefault(fac => fac.Id == id);
            if (facility == null)
                return null;

            return new FacilityDTO
            {
                Id = facility.Id,
                Name = facility.Name,
                Active = facility.Active,
            };
        }
    }
}

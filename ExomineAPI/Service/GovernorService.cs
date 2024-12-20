using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class GovernorService
    {
        public IEnumerable<GovernorDTO> GetAllGovernors()
        {
            return GovernorData.Governors.Select(gov => new GovernorDTO
            {
                Id = gov.Id,
                Name = gov.Name,
                ColonyId = gov.ColonyId,
                Active = gov.Active,
            });
        }

        public GovernorDTO GetGovernorById(int id)
        {
            var governor = GovernorData.Governors.FirstOrDefault(gov => gov.Id == id);
            if (governor == null)
                return null;

            return new GovernorDTO
            {
                Id = governor.Id,
                Name = governor.Name,
                ColonyId = governor.ColonyId,
                Active = governor.Active,
            };
        }
    }
}

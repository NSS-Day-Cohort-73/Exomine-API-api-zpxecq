using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class GovernorService
    {
        // Method to get all governors, with optional inclusion of colony data
        public IEnumerable<GovernorDTO> GetAllGovernors(bool includeColony = false)
        {
            return GovernorData.Governors.Select(gov =>
            {
                var governorDto = new GovernorDTO
                {
                    Id = gov.Id,
                    Name = gov.Name,
                    ColonyId = gov.ColonyId,
                    Active = gov.Active,
                };

                // Add colony data if the flag is true
                if (includeColony)
                {
                    var colony = ColonyData.Colonies.FirstOrDefault(col => col.Id == gov.ColonyId);
                    if (colony != null)
                    {
                        governorDto.Colony = new ColonyDTO { Id = colony.Id, Name = colony.Name };
                    }
                }

                return governorDto;
            });
        }

        // Method to get a governor by ID, always includes colony data if available
        public GovernorDTO GetGovernorById(int id)
        {
            var governor = GovernorData.Governors.FirstOrDefault(gov => gov.Id == id);
            if (governor == null)
                return null;

            var colony = ColonyData.Colonies.FirstOrDefault(col => col.Id == governor.ColonyId);

            return new GovernorDTO
            {
                Id = governor.Id,
                Name = governor.Name,
                ColonyId = governor.ColonyId,
                Active = governor.Active,
                Colony =
                    colony != null ? new ColonyDTO { Id = colony.Id, Name = colony.Name } : null,
            };
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class ColonyService
    {
        public IEnumerable<ColonyDTO> GetAllColonies()
        {
            return ColonyData.Colonies.Select(col => new ColonyDTO
            {
                Id = col.Id,
                Name = col.Name,
            });
        }

        public ColonyDTO GetColonyById(int id)
        {
            var colony = ColonyData.Colonies.FirstOrDefault(col => col.Id == id);
            if (colony == null)
                return null;

            return new ColonyDTO { Id = colony.Id, Name = colony.Name };
        }

        public ColonyDTO? GetColonyByGovernorId(int governorId)
        {
            // Find the governor by ID
            var governor = GovernorData.Governors.FirstOrDefault(gov => gov.Id == governorId);
            if (governor == null)
            {
                return null; // No governor found, return null
            }

            // Find the colony by the governor's ColonyId
            var colony = ColonyData.Colonies.FirstOrDefault(col => col.Id == governor.ColonyId);
            if (colony == null)
            {
                return null; // No colony found, return null
            }

            // Map the colony to ColonyDTO
            return new ColonyDTO { Id = colony.Id, Name = colony.Name };
        }
    }
}

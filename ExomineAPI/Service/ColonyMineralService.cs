using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class ColonyMineralService
    {
        public IEnumerable<ColonyMineralDTO> GetAllColonyMinerals()
        {
            return ColonyMineralData.ColonyMinerals.Select(cm => new ColonyMineralDTO
            {
                Id = cm.Id,
                ColonyId = cm.ColonyId,
                MineralId = cm.MineralId,
                Quantity = cm.Quantity,
            });
        }

        public ColonyMineralDTO GetColonyMineralById(int id)
        {
            var colonyMineral = ColonyMineralData.ColonyMinerals.FirstOrDefault(cm => cm.Id == id);
            if (colonyMineral == null)
                return null;

            return new ColonyMineralDTO
            {
                Id = colonyMineral.Id,
                ColonyId = colonyMineral.ColonyId,
                MineralId = colonyMineral.MineralId,
                Quantity = colonyMineral.Quantity,
            };
        }

        public ColonyMineralDTO UpdateColonyMineral(int id, ColonyMineralDTO updatedColonyMineral)
        {
            var colonyMineral = ColonyMineralData.ColonyMinerals.FirstOrDefault(cm => cm.Id == id);

            if (colonyMineral == null)
            {
                return null; // Return null if the colony mineral with the given id is not found
            }

            // Update the properties
            colonyMineral.Quantity = updatedColonyMineral.Quantity;

            // Return the updated DTO
            return new ColonyMineralDTO
            {
                Id = colonyMineral.Id,
                ColonyId = colonyMineral.ColonyId,
                MineralId = colonyMineral.MineralId,
                Quantity = colonyMineral.Quantity,
            };
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class ColonyMineralService
    {
        public IEnumerable<ColonyMineralDTO> GetAllColonyMinerals(
            bool expandColony = false,
            bool expandMineral = false,
            int? colonyId = null
        )
        {
            var query = ColonyMineralData.ColonyMinerals.AsEnumerable();

            // Filter by colonyId if provided
            if (colonyId.HasValue)
            {
                query = query.Where(cm => cm.ColonyId == colonyId.Value);
            }

            return query.Select(cm =>
            {
                var colonyMineralDto = new ColonyMineralDTO
                {
                    Id = cm.Id,
                    ColonyId = cm.ColonyId,
                    MineralId = cm.MineralId,
                    Quantity = cm.Quantity,
                };

                // Expand Colony if requested
                if (expandColony)
                {
                    var colony = ColonyData.Colonies.FirstOrDefault(c => c.Id == cm.ColonyId);
                    if (colony != null)
                    {
                        colonyMineralDto.Colony = new ColonyDTO
                        {
                            Id = colony.Id,
                            Name = colony.Name,
                        };
                    }
                }

                // Expand Mineral if requested
                if (expandMineral)
                {
                    var mineral = MineralData.Minerals.FirstOrDefault(m => m.Id == cm.MineralId);
                    if (mineral != null)
                    {
                        colonyMineralDto.Mineral = new MineralDTO
                        {
                            Id = mineral.Id,
                            Name = mineral.Name,
                        };
                    }
                }

                return colonyMineralDto;
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

        public ColonyMineralDTO CreateColonyMineral(ColonyMineralDTO newColonyMineral)
        {
            //Generate a new ID
            var newId = ColonyMineralData.ColonyMinerals.Max(cm => cm.Id) + 1;
            //Create the new ColonyMineral
            var colonyMineral = new ColonyMineral
            {
                Id = newId,
                ColonyId = newColonyMineral.ColonyId,
                MineralId = newColonyMineral.MineralId,
                Quantity = newColonyMineral.Quantity,
            };
            //Update the database
            ColonyMineralData.ColonyMinerals.Add(colonyMineral);

            //Return the new DTO
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

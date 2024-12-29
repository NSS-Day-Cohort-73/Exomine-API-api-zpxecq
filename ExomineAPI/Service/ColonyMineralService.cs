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

        public string HandlePurchase(int governorId, int facilityId, int mineralId)
        {
            // Validate input
            var facilityMineral = FacilityMineralData.FacilityMinerals.FirstOrDefault(fm =>
                fm.FacilityId == facilityId && fm.MineralId == mineralId
            );

            if (facilityMineral == null || facilityMineral.Quantity < 1)
            {
                throw new Exception("Insufficient stock for this mineral.");
            }

            // Decrement FacilityMineral quantity
            facilityMineral.Quantity--;

            // Find or create ColonyMineral
            var governor = GovernorData.Governors.FirstOrDefault(g => g.Id == governorId);
            if (governor == null)
                throw new Exception("Governor not found.");

            var colony = ColonyData.Colonies.FirstOrDefault(c => c.Id == governor.ColonyId);
            if (colony == null)
                throw new Exception("Colony not found.");

            var colonyMineral = ColonyMineralData.ColonyMinerals.FirstOrDefault(cm =>
                cm.ColonyId == colony.Id && cm.MineralId == mineralId
            );

            if (colonyMineral != null)
            {
                // Increment ColonyMineral quantity
                colonyMineral.Quantity++;
            }
            else
            {
                // Create new ColonyMineral
                var newId = ColonyMineralData.ColonyMinerals.Max(cm => cm.Id) + 1;
                colonyMineral = new ColonyMineral
                {
                    Id = newId,
                    ColonyId = colony.Id,
                    MineralId = mineralId,
                    Quantity = 1,
                };
                ColonyMineralData.ColonyMinerals.Add(colonyMineral);
            }

            return "Purchase successful.";
        }
    }
}

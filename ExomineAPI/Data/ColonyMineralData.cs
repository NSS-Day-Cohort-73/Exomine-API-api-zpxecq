using System.Collections.Generic;
using ExomineAPI.Models;

namespace ExomineAPI.Data
{
    public static class ColonyMineralData
    {
        public static List<ColonyMineral> ColonyMinerals = new List<ColonyMineral>
        {
            new ColonyMineral
            {
                Id = 1,
                ColonyId = 1,
                MineralId = 1,
                Quantity = 20,
            },
            new ColonyMineral
            {
                Id = 2,
                ColonyId = 2,
                MineralId = 3,
                Quantity = 10,
            },
            new ColonyMineral
            {
                Id = 3,
                ColonyId = 3,
                MineralId = 4,
                Quantity = 15,
            },
            new ColonyMineral
            {
                Id = 4,
                ColonyId = 4,
                MineralId = 5,
                Quantity = 30,
            },
            new ColonyMineral
            {
                Id = 5,
                ColonyId = 5,
                MineralId = 2,
                Quantity = 10,
            },
            new ColonyMineral
            {
                Id = 6,
                ColonyId = 6,
                MineralId = 6,
                Quantity = 20,
            },
            new ColonyMineral
            {
                Id = 7,
                ColonyId = 7,
                MineralId = 7,
                Quantity = 15,
            },
        };
    }
}

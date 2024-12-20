using System.Collections.Generic;
using ExomineAPI.Models;

namespace ExomineAPI.Data
{
    public static class FacilityMineralData
    {
        public static List<FacilityMineral> FacilityMinerals = new List<FacilityMineral>
        {
            new FacilityMineral
            {
                Id = 1,
                FacilityId = 1,
                MineralId = 1,
                Quantity = 100,
            },
            new FacilityMineral
            {
                Id = 2,
                FacilityId = 1,
                MineralId = 3,
                Quantity = 50,
            },
            new FacilityMineral
            {
                Id = 3,
                FacilityId = 2,
                MineralId = 4,
                Quantity = 75,
            },
            new FacilityMineral
            {
                Id = 4,
                FacilityId = 3,
                MineralId = 5,
                Quantity = 120,
            },
            new FacilityMineral
            {
                Id = 5,
                FacilityId = 4,
                MineralId = 2,
                Quantity = 200,
            },
            new FacilityMineral
            {
                Id = 6,
                FacilityId = 5,
                MineralId = 6,
                Quantity = 90,
            },
            new FacilityMineral
            {
                Id = 7,
                FacilityId = 3,
                MineralId = 7,
                Quantity = 60,
            },
            new FacilityMineral
            {
                Id = 8,
                FacilityId = 4,
                MineralId = 8,
                Quantity = 30,
            },
            new FacilityMineral
            {
                Id = 9,
                FacilityId = 2,
                MineralId = 9,
                Quantity = 40,
            },
            new FacilityMineral
            {
                Id = 10,
                FacilityId = 5,
                MineralId = 10,
                Quantity = 110,
            },
        };
    }
}

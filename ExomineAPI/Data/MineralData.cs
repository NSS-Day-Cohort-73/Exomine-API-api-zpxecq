using System.Collections.Generic;
using ExomineAPI.Models;

namespace ExomineAPI.Data
{
    public static class MineralData
    {
        public static List<Mineral> Minerals = new List<Mineral>
        {
            new Mineral { Id = 1, Name = "Iron" },
            new Mineral { Id = 2, Name = "Copper" },
            new Mineral { Id = 3, Name = "Uranium" },
            new Mineral { Id = 4, Name = "Gold" },
            new Mineral { Id = 5, Name = "Silver" },
            new Mineral { Id = 6, Name = "Tin" },
            new Mineral { Id = 7, Name = "Lead" },
            new Mineral { Id = 8, Name = "Zinc" },
            new Mineral { Id = 9, Name = "Nickel" },
            new Mineral { Id = 10, Name = "Cobalt" },
        };
    }
}

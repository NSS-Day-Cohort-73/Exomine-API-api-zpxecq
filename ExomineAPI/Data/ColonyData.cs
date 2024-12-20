using System.Collections.Generic;
using ExomineAPI.Models;

namespace ExomineAPI.Data
{
    public static class ColonyData
    {
        public static List<Colony> Colonies = new List<Colony>
        {
            new Colony { Id = 1, Name = "Scadrial" },
            new Colony { Id = 2, Name = "Roshar" },
            new Colony { Id = 3, Name = "Nalthis" },
            new Colony { Id = 4, Name = "Taldain" },
            new Colony { Id = 5, Name = "Sel" },
            new Colony { Id = 6, Name = "Threnody" },
            new Colony { Id = 7, Name = "First of the Sun" },
        };
    }
}

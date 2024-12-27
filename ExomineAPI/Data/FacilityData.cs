using System.Collections.Generic;
using ExomineAPI.Models;

namespace ExomineAPI.Data
{
    public static class FacilityData
    {
        public static List<Facility> Facilities = new List<Facility>
        {
            new Facility
            {
                Id = 1,
                Name = "Ba Sing Se",
                Active = true,
            },
            new Facility
            {
                Id = 2,
                Name = "Omashu",
                Active = true,
            },
            new Facility
            {
                Id = 3,
                Name = "Republic City",
                Active = true,
            },
            new Facility
            {
                Id = 4,
                Name = "Ember Asteroid Field",
                Active = false,
            },
            new Facility
            {
                Id = 5,
                Name = "Kyoshi Asteroid Field",
                Active = true,
            },
        };
    }
}

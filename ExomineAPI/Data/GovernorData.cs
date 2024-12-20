using System.Collections.Generic;
using ExomineAPI.Models;

namespace ExomineAPI.Data
{
    public static class GovernorData
    {
        public static List<Governor> Governors = new List<Governor>
        {
            new Governor
            {
                Id = 1,
                Name = "Hamlet",
                ColonyId = 1,
                Active = true,
            },
            new Governor
            {
                Id = 2,
                Name = "Othello",
                ColonyId = 2,
                Active = false,
            },
            new Governor
            {
                Id = 3,
                Name = "Macbeth",
                ColonyId = 3,
                Active = true,
            },
            new Governor
            {
                Id = 4,
                Name = "Juliet",
                ColonyId = 4,
                Active = false,
            },
            new Governor
            {
                Id = 5,
                Name = "Ophelia",
                ColonyId = 5,
                Active = true,
            },
            new Governor
            {
                Id = 6,
                Name = "Lear",
                ColonyId = 6,
                Active = true,
            },
            new Governor
            {
                Id = 7,
                Name = "Prospero",
                ColonyId = 7,
                Active = false,
            },
            new Governor
            {
                Id = 8,
                Name = "Falstaff",
                ColonyId = 1,
                Active = true,
            },
            new Governor
            {
                Id = 9,
                Name = "Iago",
                ColonyId = 2,
                Active = true,
            },
            new Governor
            {
                Id = 10,
                Name = "Portia",
                ColonyId = 3,
                Active = false,
            },
            new Governor
            {
                Id = 11,
                Name = "Benedick",
                ColonyId = 4,
                Active = true,
            },
            new Governor
            {
                Id = 12,
                Name = "Titania",
                ColonyId = 5,
                Active = true,
            },
        };
    }
}

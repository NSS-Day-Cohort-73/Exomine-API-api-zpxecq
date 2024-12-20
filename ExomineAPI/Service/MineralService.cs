using System.Collections.Generic;
using System.Linq;
using ExomineAPI.Data;
using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Services
{
    public class MineralService
    {
        public IEnumerable<MineralDTO> GetAllMinerals()
        {
            return MineralData.Minerals.Select(min => new MineralDTO
            {
                Id = min.Id,
                Name = min.Name,
            });
        }

        public MineralDTO GetMineralById(int id)
        {
            var mineral = MineralData.Minerals.FirstOrDefault(min => min.Id == id);
            if (mineral == null)
                return null;

            return new MineralDTO { Id = mineral.Id, Name = mineral.Name };
        }
    }
}

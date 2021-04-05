using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Abstractions.Services;

namespace BattleShips.Core.Services
{
    public class MapService : IMapService
    {
        private readonly IRepository<Map> mapRepository;

        public MapService(IRepository<Map> mapRepository)
        {
            this.mapRepository = mapRepository;
        }
        public Map CreateMap(int rows, int columns)
        {
            var map =  new Map(rows, columns);
            mapRepository.Save(map);
            return mapRepository.Entity;
        }

      
    }
}

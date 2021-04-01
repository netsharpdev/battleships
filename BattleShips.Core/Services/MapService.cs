using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Abstractions.Services;
using BattleShips.Core.Utilities;

namespace BattleShips.Core.Services
{
    public class MapService : IMapService
    {
        private readonly IMapRepository mapRepository;

        public MapService(IMapRepository mapRepository)
        {
            this.mapRepository = mapRepository;
        }
        public Map CreateMap(int rows, int columns)
        {
            var map =  new Map(rows, columns);
            mapRepository.SaveMap(map);
            return mapRepository.Map;
        }

      
    }
}

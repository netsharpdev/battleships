using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Services;

namespace BattleShips.Core.Services
{
    public class MapService : IMapService
    {
        public Map CreateMap(int columns, int rows)
        {
            return new Map(columns, rows);
        }

        public string DrawMap(Map map)
        {
            throw new NotImplementedException();
        }
    }
}

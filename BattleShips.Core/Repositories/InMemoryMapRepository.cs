using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;

namespace BattleShips.Core.Repositories
{
    public class InMemoryMapRepository : IMapRepository
    {
        public Map Map { get; private set; }

        public void SaveMap(Map map)
        {
            Map = map;
        }
    }
}

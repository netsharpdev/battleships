using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;

namespace BattleShips.Core.Repositories
{
    public class InMemoryMapRepository : IRepository<Map>
    {
        public Map Entity { get; private set; }

        public void Save(Map map)
        {
            Entity = map;
        }
    }
}

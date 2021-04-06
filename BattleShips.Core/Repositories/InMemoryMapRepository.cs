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

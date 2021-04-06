using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;

namespace BattleShips.Core.Repositories
{
    public class InMemoryScoreRepository : IRepository<Score>
    {
        public Score Entity { get; private set; }
        public void Save(Score score)
        {
            Entity = score;
        }
    }
}

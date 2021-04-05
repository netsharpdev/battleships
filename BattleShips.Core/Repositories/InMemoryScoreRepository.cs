using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

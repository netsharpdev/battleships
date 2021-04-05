using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Core.Abstractions.Repositories
{
    public interface IScoreRepository
    {
        Score Score { get; }
        void SaveScore(Score score);
    }
}

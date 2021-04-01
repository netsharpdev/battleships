using System.Collections.Generic;
using BattleShips.Core.Abstractions.Enums;
using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Core.Abstractions.Services
{
    public interface IBattleService
    {
        ShootStatus Shoot(int row, string column);
    }
}

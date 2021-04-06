using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Core.Abstractions.Services
{
    public interface IBattleService
    {
        ShootResult Shoot(int row, int column);
        Score GetScore();
    }
}

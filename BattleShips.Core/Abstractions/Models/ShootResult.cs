using BattleShips.Core.Abstractions.Enums;

namespace BattleShips.Core.Abstractions.Models
{
    public class ShootResult
    {
        public Score Score { get; set; }
        public ShootStatus LastShootStatus { get; set; }
    }
}

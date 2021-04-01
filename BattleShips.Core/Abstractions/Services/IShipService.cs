using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Core.Abstractions.Services
{
    public interface IShipService
    {
        Ship PlaceShip(int row, int column, int length);
    }
}

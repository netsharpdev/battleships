using BattleShips.Core.Abstractions.Enums;
using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Core.Abstractions.Services
{
    public interface IShipService
    {
        PlacingShipResult PlaceShip(int row, int column, Ship ship);
        PlacingShipResult RandomlyPlaceShip(int length);
    }
}

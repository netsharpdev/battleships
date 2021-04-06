using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Services
{
    public interface IDrawService
    {
        string DrawMap(Map map);
    }
}

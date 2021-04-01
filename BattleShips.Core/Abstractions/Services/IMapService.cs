using System.Collections.Generic;
using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Core.Abstractions.Services
{
    public interface IMapService
    {
        Map CreateMap(int rows, int columns);
    }
}

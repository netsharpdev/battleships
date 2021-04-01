using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Core.Abstractions.Services
{
    public interface IDrawService<T>
    {
        T DrawMap(Map map);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;

namespace BattleShips.Services
{
    public interface IDrawService
    {
        string DrawMap(Map map);
    }
}

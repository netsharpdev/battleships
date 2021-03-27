using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Models;

namespace BattleShips
{
    public interface IMapService
    {
        Map CreateMap(int rows, int columns);
        string DrawMap(Map map, Hit[] hits);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Models;

namespace BattleShips
{
    public interface IShipService
    {
        Ship PlaceShip(string row, int column, int length);
    }
}

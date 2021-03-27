using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Models;

namespace BattleShips
{
    public interface IBattleService
    {
        ShootStatus Shoot(Dictionary<string, int[]> map, string row, int column);

    }
}

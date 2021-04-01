using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Services;

namespace BattleShips.Core.Abstractions.Factories
{
    public interface IBattleServiceFactory
    {
        IBattleService CreateBattleService(Map map);
    }
}

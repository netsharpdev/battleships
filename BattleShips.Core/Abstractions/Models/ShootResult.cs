using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Enums;

namespace BattleShips.Core.Abstractions.Models
{
    public class ShootResult
    {
        public Score Score { get; set; }
        public ShootStatus LastShootStatus { get; set; }
    }
}

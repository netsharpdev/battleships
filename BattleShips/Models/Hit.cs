using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    public class Hit
    {
        public string Row { get; set; }
        public int Column { get; set; }
        public bool IsMissed { get; set; }
    }
}

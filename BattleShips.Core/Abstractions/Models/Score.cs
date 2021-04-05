using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Core.Abstractions.Models
{
    public class Score
    {
        public int Hits { get; set; }
        public int Misses { get; set; }
        public int Sinks { get; set; }
    }
}

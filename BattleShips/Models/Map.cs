using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    public class Map
    {
        public Dictionary<string, int[]> Fields { get; set; }
        public List<Hit> Hits { get; } = new List<Hit>();
    }
}

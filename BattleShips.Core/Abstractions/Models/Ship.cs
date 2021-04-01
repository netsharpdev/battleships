using System;
using System.Collections.Generic;

namespace BattleShips.Core.Abstractions.Models
{
    public class Ship
    {
        public Guid Id { get; set; }
        public string[] Coordinates { get; set; }
        public bool IsDestroyed { get; set; }
        public Dictionary<string, bool> Hits { get; set; }
    }
}

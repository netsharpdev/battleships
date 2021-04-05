using System;
using System.Collections.Generic;
using BattleShips.Core.Abstractions.Enums;

namespace BattleShips.Core.Abstractions.Models
{
    public class Ship
    {
        public Ship(int length)
        {
            Length = length;
            Coordinates = new List<Coordinates>();
        }
        public List<Coordinates> Coordinates { get; }
        public bool IsDestroyed => Coordinates.Count > 0 && Coordinates.TrueForAll(x => x.IsHit);
        public int Length { get; }
        public Direction Direction { get; set; }
    }
}

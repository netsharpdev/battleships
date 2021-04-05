using System;
using System.Collections.Generic;
using BattleShips.Core.Abstractions.Enums;

namespace BattleShips.Core.Abstractions.Models
{
    public class Ship
    {
        public Ship(int length)
        {
            if (length > 5 || length < 4)
            {
                throw new ArgumentOutOfRangeException("Ship cannot be longer than 5 or shorter than 4");
            }
            Length = length;
            Coordinates = new List<Coordinates>();
        }
        public List<Coordinates> Coordinates { get; }
        public bool IsDestroyed => Coordinates.Count > 0 && Coordinates.TrueForAll(x => x.IsHit);
        public int Length { get; }
        public Direction Direction { get; set; }
    }
}

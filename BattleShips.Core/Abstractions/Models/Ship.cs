using System;
using System.Collections.Generic;
using BattleShips.Core.Abstractions.Enums;

namespace BattleShips.Core.Abstractions.Models
{
    public class Ship
    {
        public Ship(int length)
        {
            Id = Guid.NewGuid();
            Length = length;
            Coordinates = new Coordinates[length];
        }
        public Guid Id { get; }
        public Coordinates[] Coordinates { get; set; }
        public Direction Direction { get; set; }
        public bool IsDestroyed { get; set; }
        public int Length { get;  }
    }
}

﻿namespace BattleShips.Core.Abstractions.Models
{
    public class Field
    {
        public bool IsShoot { get; set; }
        public Ship Ship { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
    }
}

using System;
using System.Linq;
using BattleShips.Utilities;

namespace BattleShips.Models
{
    public class FieldCoordinates
    {
        public FieldCoordinates(string input)
        {
            Column = ColumnUtility.GetColumnNumber(input.First().ToString().ToUpper());

            var row = (int.Parse(input[1..]) - 1);
            if (row < 0)
            {
                throw new ArgumentOutOfRangeException("Row specifier cannot be less than 1");
            }

            Row = row;
        }
        public int Row { get; }
        public int Column { get; }
    }
}

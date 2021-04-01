using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Core.Utilities
{
    internal static class ColumnUtility
    {
        internal static int GetColumnNumber(string columnLetter) =>
            columnLetter switch
            {
                "A" => 1,
                "B" => 2,
                "C" => 3,
                "D" => 4,
                "E" => 5,
                "F" => 6,
                "G" => 7,
                "H" => 8,
                "I" => 9,
                "J" => 10,
                _ => throw new ArgumentOutOfRangeException()
            };
    }

}

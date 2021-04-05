using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips.Utilities
{
    public static class ColumnUtility
    {
        private static Dictionary<string, int> columnNumberMapping = new Dictionary<string, int>();

        private static IReadOnlyList<string> availableLetters = new []
            {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
        static ColumnUtility()
        {
            var index = 0;
            foreach (var availableLetter in availableLetters)
            {
                columnNumberMapping.Add(availableLetter, index);
                index++;
            }
        }

        public static int GetColumnNumber(string columnLetter)
        {
            if (!availableLetters.Contains(columnLetter))
            {
                throw new ArgumentOutOfRangeException();
            }

            return columnNumberMapping[columnLetter];
        }

        public static string GetColumnLetter(int column)
        {
            if (column < 0 || column > columnNumberMapping.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return columnNumberMapping.First(x => x.Value == column).Key;
        }
    }

}

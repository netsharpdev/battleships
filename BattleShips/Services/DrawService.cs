using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Utilities;

namespace BattleShips.Services
{
    public class DrawService : IDrawService
    {
        public string DrawMap(Map map)
        {
            if (map == null || map.Fields == null)
            {
                throw new ArgumentNullException();
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(DrawColumnNames(map.Fields[0].Length));
            for (int row = 0; row < map.Fields.Length; row++)
            {
                DrawRow(map.Fields, row, stringBuilder);
            }

            return stringBuilder.ToString();
        }

        private static void DrawRow(Field[][] fields, int row, StringBuilder stringBuilder)
        {
            var rowBuilder = new StringBuilder();
            rowBuilder.Append(row + 1 + row > 9 ? string.Empty : "_");
            for (int column = 0; column < fields[row].Length; column++)
            {
                DrawColumnContent(fields[row][column], rowBuilder);
            }

            stringBuilder.AppendLine(rowBuilder.ToString());
        }

        private static void DrawColumnContent(Field field, StringBuilder rowBuilder)
        {
            if (field.IsShoot)
            {
                rowBuilder.Append(field.Ship != null ? "x" : "o");
            }
            else
            {
                rowBuilder.Append("+");
            }
        }

        private string DrawColumnNames(int columns)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("__");
            for (int i = 0; i < columns; i++)
            {
                stringBuilder.Append(ColumnUtility.GetColumnLetter(i));
            }

            return stringBuilder.ToString();
        }
    }
}

using System;
using System.Collections.Generic;

namespace BattleShips.Core.Abstractions.Models
{
    public class Map
    {
        public Map(int columns, int rows)
        {
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentOutOfRangeException("Minimum map size is 1x1");
            }

            Fields = new Field[columns][];
            for (int i = 0; i < columns; i++)
            {
                Fields[i] = new Field[rows];
                for (int j = 0; j < rows; j++)
                {
                    Fields[i][j] = new Field();
                }
            }
        }
        public Field[][] Fields { get; }
    }
}

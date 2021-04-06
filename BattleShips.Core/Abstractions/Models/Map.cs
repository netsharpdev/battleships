using System;

namespace BattleShips.Core.Abstractions.Models
{
    public class Map
    {
        public Map(int rows, int columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentOutOfRangeException("Minimum map size is 1x1");
            }

            Fields = new Field[rows][];
            for (var i = 0; i < rows; i++)
            {
                Fields[i] = new Field[columns];
                for (var j = 0; j < columns; j++)
                {
                    Fields[i][j] = new Field();
                }
            }
        }
        public Field[][] Fields { get; }
    }
}

namespace BattleShips.Core.Abstractions.Models
{
    public class Coordinates
    {
        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public int Row { get; }
        public int Column { get; }
        public bool IsHit { get; set; }
    }
}

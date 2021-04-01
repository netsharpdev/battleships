namespace BattleShips.Core.Abstractions.Models
{
    public class Hit
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsMissed { get; set; }
    }
}

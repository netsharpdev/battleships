using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Core.Abstractions.Models
{
    public class PlacingShipResult
    {
        public Ship Ship { get; set; }
        public bool Success => string.IsNullOrEmpty(Error);
        public string Error { get; private set; }

        public static PlacingShipResult WithError(string error)
        {
            return new PlacingShipResult
            {
                Error = error
            };
        }
    }
}

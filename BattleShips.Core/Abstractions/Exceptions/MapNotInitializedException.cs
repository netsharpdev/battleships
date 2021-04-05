using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Core.Abstractions.Exceptions
{
    public class MapNotInitializedException : Exception
    {
        public MapNotInitializedException() : base("Map has not been initialized!")
        {
        }
    }
}

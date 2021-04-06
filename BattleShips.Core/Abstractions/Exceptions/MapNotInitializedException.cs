using System;

namespace BattleShips.Core.Abstractions.Exceptions
{
    public class MapNotInitializedException : Exception
    {
        public MapNotInitializedException() : base("Map has not been initialized!")
        {
        }
    }
}

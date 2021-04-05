using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Enums;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Abstractions.Services;

namespace BattleShips.Core.Services
{
    public class ShipService : IShipService
    {
        private readonly IMapRepository mapRepository;

        public ShipService(IMapRepository mapRepository)
        {
            this.mapRepository = mapRepository;
        }
        public PlacingShipResult PlaceShip(int row, int column, Ship ship)
        {
            throw new NotImplementedException();
        }
        public PlacingShipResult RandomlyPlaceShip(int length)
        {
            var ship = new Ship(length);
            var map = mapRepository.Map;
            if (map == null)
            {
                throw new NullReferenceException("Map cannot be null!");
            }

            var random = new Random();
            var result = new PlacingShipResult();
            while (!result.Success)
            {
                var row = random.Next(0, map.Fields.Length - 1);
                var column = random.Next(0, map.Fields[0].Length - 1);
                result = PlaceShip(row, column, ship);
            }

            return result;
        }
    }
}

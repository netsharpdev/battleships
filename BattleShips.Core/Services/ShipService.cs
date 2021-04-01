using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Ship PlaceShip(int row, int column, int length)
        {
            throw new NotImplementedException();
        }
    }
}

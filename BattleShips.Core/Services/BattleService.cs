using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Enums;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Abstractions.Services;

namespace BattleShips.Core.Services
{
    public class BattleService : IBattleService
    {
        private readonly IMapRepository mapRepository;

        public BattleService(IMapRepository mapRepository)
        {
            this.mapRepository = mapRepository;
        }
        public ShootStatus Shoot(int row, string column)
        {
            throw new NotImplementedException();
        }
    }
}

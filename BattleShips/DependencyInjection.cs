using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Abstractions.Services;
using BattleShips.Core.Repositories;
using BattleShips.Core.Services;
using BattleShips.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShips
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IMapRepository, InMemoryMapRepository>();
            serviceCollection.AddSingleton<IScoreRepository, InMemoryScoreRepository>();
            serviceCollection.AddScoped<IBattleService, BattleService>();
            serviceCollection.AddScoped<IMapService, MapService>();
            serviceCollection.AddScoped<IShipService, ShipService>();
            serviceCollection.AddScoped<IDrawService, DrawService>();
            return serviceCollection;
        }
    }
}

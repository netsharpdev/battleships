using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Abstractions.Services;
using BattleShips.Core.Repositories;
using BattleShips.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShips.Core.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IRepository<Map>, InMemoryMapRepository>();
            serviceCollection.AddSingleton<IRepository<Score>, InMemoryScoreRepository>();
            serviceCollection.AddScoped<IBattleService, BattleService>();
            serviceCollection.AddScoped<IMapService, MapService>();
            serviceCollection.AddScoped<IShipService, ShipService>();
            return serviceCollection;
        }
    }
}

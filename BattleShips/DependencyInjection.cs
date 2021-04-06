using BattleShips.Core.IoC;
using BattleShips.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShips
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterCoreServices();
            serviceCollection.AddScoped<IDrawService, DrawService>();
            serviceCollection.AddScoped<IBattleShipGameService, BattleShipGameService>();
            return serviceCollection;
        }
    }
}

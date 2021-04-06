using BattleShips.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = DependencyInjection.RegisterServices();

            var provider = serviceCollection.BuildServiceProvider();

            provider.GetService<IBattleShipGameService>().Play(10);
        }
    }
}

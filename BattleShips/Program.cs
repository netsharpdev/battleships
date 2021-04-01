using System;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Abstractions.Services;
using BattleShips.Core.Repositories;
using BattleShips.Core.Services;
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
        }
    }
}

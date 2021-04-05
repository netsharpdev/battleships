using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Enums;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Services;
using BattleShips.Models;
using BattleShips.Utilities;

namespace BattleShips.Services
{
    public class BattleShipGameService : IBattleShipGameService
    {
        private readonly IDrawService drawService;
        private readonly IMapService mapService;
        private readonly IBattleService battleService;
        private readonly IShipService shipService;

        public BattleShipGameService(IDrawService drawService,
            IMapService mapService,
            IBattleService battleService,
            IShipService shipService)
        {
            this.drawService = drawService;
            this.mapService = mapService;
            this.battleService = battleService;
            this.shipService = shipService;
        }

        public void Play(int mapSize)
        {
            var map = PrepareMap(mapSize);
            while (true)
            {
                var score = battleService.GetScore();
                Console.WriteLine("Hits: " + score.Hits);
                Console.WriteLine("Misses: " + score.Misses);
                Console.WriteLine("Sinks: " + score.Sinks);

                var textMap = drawService.DrawMap(map);
                Console.Write(textMap);
                Console.WriteLine();
                Console.WriteLine("Give me coordinates to hit!");
                var input = Console.ReadLine();
                if (input.Length > 3 ||input.Length < 2 || !ValidateColumn(input) || !ValidateRows(input, mapSize))
                {
                    Console.WriteLine("Incorrect format");
                    continue;
                }

                var coordinates = new FieldCoordinates(input);
                var result = battleService.Shoot(coordinates.Row, coordinates.Column);
                if (result.LastShootStatus == ShootStatus.AlreadyShoot)
                {
                    Console.WriteLine("You already shoot this coordinate! Choose something different!");
                    continue;
                }

                if (result.LastShootStatus == ShootStatus.Destroyed)
                {
                    Console.WriteLine("Wohoo! You have destroyed a ship!");
                    if (result.Score.Sinks == 3)
                    {
                        Console.WriteLine("Game is over! You won!");
                        break;
                    }
                }

                if (result.LastShootStatus == ShootStatus.Hit)
                {
                    Console.WriteLine("Wohoo! You have hit the target!");
                }

                if (result.LastShootStatus == ShootStatus.Missed)
                {
                    Console.WriteLine("Damn! You missed! Try again!");
                }
            }

            Console.ReadKey();
        }

        private bool ValidateColumn(string input)
        {
            var column = input.First();
            try
            {
                ColumnUtility.GetColumnNumber(column.ToString().ToUpper());
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }
        private bool ValidateRows(string input, int rowNumbers)
        {
            var row = input[1..];
            return int.TryParse(row, out int rowInt) && rowInt <= rowNumbers;
        }
        private Map PrepareMap(int mapSize)
        {
            var map = mapService.CreateMap(mapSize, mapSize);
            shipService.RandomlyPlaceShip(4);
            shipService.RandomlyPlaceShip(4);
            shipService.RandomlyPlaceShip(5);
            return map;
        }
    }
}

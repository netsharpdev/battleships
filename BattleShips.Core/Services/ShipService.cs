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
        private const string FieldAlreadyOccupiedError = "There is already ship on provided coordinates";
        private const string ShipOutOfDimensionsError = "Ship cannot exceed map dimensions";
        public ShipService(IMapRepository mapRepository)
        {
            this.mapRepository = mapRepository;
        }
        public PlacingShipResult PlaceShip(int row, int column, Ship ship)
        {
            var map = mapRepository.Map;

            var result = ValidateInput(row, column, ship, map);
            if (!result.Success)
            {
                return result;
            }

            result.Ship = ship;
            //calculate fields
            if (ship.Direction == Direction.Bottom)
            {
                for (var i = row; i < row + result.Ship.Length; i++)
                {
                    if (map.Fields[i][column].Ship != null)
                    {
                        return PlacingShipResult.WithError(FieldAlreadyOccupiedError);
                    }
                    result.Ship.Coordinates.Add(new Coordinates(i, column));
                    map.Fields[i][column].Ship = result.Ship;
                }
            }
            if (result.Ship.Direction == Direction.Top)
            {
                for (var i = row; i > row - result.Ship.Length; i--)
                {
                    if (map.Fields[i][column].Ship != null)
                    {
                        return PlacingShipResult.WithError(FieldAlreadyOccupiedError);
                    }
                    result.Ship.Coordinates.Add(new Coordinates(i, column));
                    map.Fields[i][column].Ship = result.Ship;
                }
            }
            if (result.Ship.Direction == Direction.Right)
            {
                var mapRow = map.Fields[row];
                for (var i = column; i < column + result.Ship.Length; i++)
                {
                    if (mapRow[i].Ship != null)
                    {
                        return PlacingShipResult.WithError(FieldAlreadyOccupiedError);
                    }
                    result.Ship.Coordinates.Add(new Coordinates(row, i));
                    map.Fields[row][i].Ship = result.Ship;
                }
            }
            if (result.Ship.Direction == Direction.Left)
            {
                var mapRow = map.Fields[row];
                for (var i = column; i > column - result.Ship.Length; i--)
                {
                    if (mapRow[i].Ship != null)
                    {
                        return PlacingShipResult.WithError(FieldAlreadyOccupiedError);
                    }
                    result.Ship.Coordinates.Add(new Coordinates(row, i));
                    map.Fields[row][i].Ship = result.Ship;
                }
            }

            return result;

        }

        private static PlacingShipResult ValidateInput(int row, int column, Ship ship, Map map)
        {
            switch (ship.Direction)
            {
                case Direction.Top:
                    if (row - ship.Length < -1)
                    {
                        return PlacingShipResult.WithError(ShipOutOfDimensionsError);
                    }

                    break;
                case Direction.Bottom:
                    if (row + ship.Length >= map.Fields.Length)
                    {
                        return PlacingShipResult.WithError(ShipOutOfDimensionsError);
                    }

                    break;
                case Direction.Left:
                    if (column - ship.Length < -1)
                    {
                        return PlacingShipResult.WithError(ShipOutOfDimensionsError);
                    }

                    break;
                case Direction.Right:
                    if (column + ship.Length >= map.Fields[0].Length)
                    {
                        return PlacingShipResult.WithError(ShipOutOfDimensionsError);
                    }

                    break;
            }

            return map.Fields[row][column].Ship != null ? PlacingShipResult.WithError(FieldAlreadyOccupiedError) : new PlacingShipResult();
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

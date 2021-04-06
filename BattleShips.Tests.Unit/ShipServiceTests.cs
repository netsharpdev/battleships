using System;
using System.Linq;
using BattleShips.Core.Abstractions.Enums;
using BattleShips.Core.Abstractions.Exceptions;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Repositories;
using BattleShips.Core.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BattleShips.Tests.Unit
{
    public class ShipServiceTests
    {
        [TestCase(0,0, 5, Direction.Bottom)]
        [TestCase(4,9, 4, Direction.Top)]
        [TestCase(9,4, 4, Direction.Top)]
        public void
            PlaceShip_WHEN_InvokedWithTopOrBottomDirection_THEN_ReturnShipWithFieldsNextToEachOtherInSameColumn(int row, int column, int shipLength, Direction direction)
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            mapRepoMock.SetupGet(c => c.Entity).Returns(new Map(10, 10));
            var shipService = new ShipService(mapRepoMock.Object);
            var ship = new Ship(shipLength)
            {
                Direction = direction
            };
            var result = shipService.PlaceShip(row, column, ship);

            result.Success.Should().BeTrue();
            result.Error.Should().BeNullOrEmpty();
            result.Ship.Coordinates.Count.Should().Be(shipLength);
            result.Ship.Coordinates.Select(c=>c.Column).Should().AllBeEquivalentTo(column);
            result.Ship.Coordinates.Select(c => c.Row).Should().OnlyHaveUniqueItems();
        }
        [TestCase(1, 4, 5, Direction.Left)]
        [TestCase(2, 5, 4, Direction.Right)]
        [TestCase(5, 1, 4, Direction.Right)]
        public void
            PlaceShip_WHEN_InvokedWithLeftOrRightDirection_THEN_ReturnShipWithFieldsNextToEachOtherInSameRow(int row, int column, int shipLength, Direction direction)
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            mapRepoMock.SetupGet(c => c.Entity).Returns(new Map(10, 10));
            var shipService = new ShipService(mapRepoMock.Object);
            var ship = new Ship(shipLength)
            {
                Direction = direction
            };
            var result = shipService.PlaceShip(row, column, ship);

            result.Error.Should().BeNullOrEmpty();
            result.Ship.Coordinates.Count.Should().Be(shipLength);
            result.Ship.Coordinates.Select(c => c.Row).Should().AllBeEquivalentTo(row);
            result.Ship.Coordinates.Select(c => c.Column).Should().OnlyHaveUniqueItems();
        }
        [TestCase(1, 5, 5, Direction.Left)]
        [TestCase(2, 4, 4, Direction.Right)]
        [TestCase(5, 4, 4, Direction.Top)]
        [TestCase(3, 2, 4, Direction.Bottom)]
        public void
            PlaceShip_WHEN_InvokedAndCollisionWithShipDetected_THEN_ReturnSuccessFalse(int row, int column, int shipLength, Direction direction)
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            var mapWithShips = new Map(10, 10);

            mapWithShips.Fields[row][column+1].Ship = new Ship(4);
            mapWithShips.Fields[row][column+2].Ship = new Ship(4);
            mapWithShips.Fields[row][column+3].Ship = new Ship(4);
            mapWithShips.Fields[row][column+4].Ship = new Ship(4);

            mapWithShips.Fields[row-1][column].Ship = new Ship(4);
            mapWithShips.Fields[row][column].Ship = new Ship(4);
            mapWithShips.Fields[row+1][column].Ship = new Ship(4);
            mapWithShips.Fields[row+2][column].Ship = new Ship(4);

            mapWithShips.Fields[row-1][column-1].Ship = new Ship(4);
            mapWithShips.Fields[row][column-1].Ship = new Ship(4);
            mapWithShips.Fields[row+1][column-1].Ship = new Ship(4);
            mapWithShips.Fields[row+2][column-1].Ship = new Ship(4);

            mapRepoMock.SetupGet(c => c.Entity).Returns(mapWithShips);
            var shipService = new ShipService(mapRepoMock.Object);
            var ship = new Ship(shipLength)
            {
                Direction = direction
            };
            var result = shipService.PlaceShip(row, column, ship);

            result.Success.Should().BeFalse();
            result.Error.Should().BeEquivalentTo("There is already ship on provided coordinates");
        }
        [TestCase(1, 0, 5, Direction.Left)]
        [TestCase(2, 9, 4, Direction.Right)]
        [TestCase(5, 7, 4, Direction.Right)]
        public void
            PlaceShip_WHEN_InvokedAndCollisionWithBorderDetected_THEN_ReturnSuccessFalse(int row, int column, int shipLength, Direction direction)
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            mapRepoMock.SetupGet(c => c.Entity).Returns(new Map(10, 10));
            var shipService = new ShipService(mapRepoMock.Object);
            var ship = new Ship(shipLength)
            {
                Direction = direction
            };
            var result = shipService.PlaceShip(row, column, ship);

            result.Success.Should().BeFalse();
            result.Error.Should().BeEquivalentTo("Ship cannot exceed map dimensions");
        }

        [TestCase(4)]
        [TestCase(5)]
        public void
            RandomlyPlaceShip_WHEN_Invoked_THEN_ReturnRandomlyPlacedShip(int length)
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            var mapWithShips = new Map(10, 10);

            mapWithShips.Fields[0][1].Ship = new Ship(4);
            mapWithShips.Fields[0][2].Ship = new Ship(4);
            mapWithShips.Fields[0][3].Ship = new Ship(4);
            mapWithShips.Fields[0][4].Ship = new Ship(4);

            mapWithShips.Fields[0][0].Ship = new Ship(4);
            mapWithShips.Fields[1][0].Ship = new Ship(4);
            mapWithShips.Fields[2][0].Ship = new Ship(4);
            mapWithShips.Fields[3][0].Ship = new Ship(4);

            mapRepoMock.SetupGet(c => c.Entity).Returns(new Map(10, 10));
            var shipService = new ShipService(mapRepoMock.Object);
            var result = shipService.RandomlyPlaceShip(length);

            result.Success.Should().BeTrue();
            result.Ship.Should().NotBeNull();
            result.Ship.Coordinates.Count.Should().Be(length);
        }
        [Test]
        public void RandomlyPlaceShip_WHEN_InvokedAndNoMapFound_THEN_ThrowsMapNotInitializedException()
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            mapRepoMock.SetupGet(c => c.Entity).Returns((Map)null);
            var shipService = new ShipService(mapRepoMock.Object);

            var act = new Func<PlacingShipResult>(() => shipService.RandomlyPlaceShip(4));
            act.Should().ThrowExactly<MapNotInitializedException>();
        }
        [Test]
        public void PlaceShip_WHEN_InvokedAndNoMapFound_THEN_ThrowsMapNotInitializedException()
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            mapRepoMock.SetupGet(c => c.Entity).Returns((Map)null);
            var shipService = new ShipService(mapRepoMock.Object);

            var act = new Func<PlacingShipResult>(() => shipService.PlaceShip(4,0, new Ship(4)));
            act.Should().ThrowExactly<MapNotInitializedException>();
        }
    }
}

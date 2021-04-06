using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class BattleServiceTests
    {
        [Test]
        public void Shoot_WHEN_InvokedAndShipHit_THEN_ReturnsHitStatus()
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            var scoreRepositoryMock = new Mock<IRepository<Score>>();
            scoreRepositoryMock.SetupGet(c => c.Entity).Returns(new Score());
            var mapWithShips = new Map(10, 10);
            var ship = CreateShipWithCoordinates();
            AssignShipToMap(mapWithShips, ship);
            mapRepoMock.SetupGet(c => c.Entity).Returns(mapWithShips);
            var battleService = new BattleService(mapRepoMock.Object, scoreRepositoryMock.Object);

            var result = battleService.Shoot(0, 1);
            result.LastShootStatus.Should().BeEquivalentTo(ShootStatus.Hit);
        }

        [Test]
        public void Shoot_WHEN_InvokedAndShipDestroyed_THEN_ReturnsDestroyedStatus()
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            var scoreRepositoryMock = new Mock<IRepository<Score>>();
            scoreRepositoryMock.SetupGet(c => c.Entity).Returns(new Score());
            var mapWithShips = new Map(10, 10);
            var ship = CreateShipWithCoordinates();
            AssignShipToMap(mapWithShips, ship);
            mapRepoMock.SetupGet(c => c.Entity).Returns(mapWithShips);
            var battleService = new BattleService(mapRepoMock.Object, scoreRepositoryMock.Object);

            var result = battleService.Shoot(0, 4);
            result.LastShootStatus.Should().BeEquivalentTo(ShootStatus.Destroyed);
        }

        [Test]
        public void Shoot_WHEN_InvokedAndMissed_THEN_ReturnsMissedStatus()
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            var scoreRepositoryMock = new Mock<IRepository<Score>>();
            scoreRepositoryMock.SetupGet(c => c.Entity).Returns(new Score());
            var mapWithShips = new Map(10, 10);
            var ship = CreateShipWithCoordinates();
            AssignShipToMap(mapWithShips, ship);
            mapRepoMock.SetupGet(c => c.Entity).Returns(mapWithShips);
            var battleService = new BattleService(mapRepoMock.Object, scoreRepositoryMock.Object);

            var result = battleService.Shoot(1, 1);
            result.LastShootStatus.Should().BeEquivalentTo(ShootStatus.Missed);
        }

        [Test]
        public void Shoot_WHEN_InvokedWithAlreadyUsedField_THEN_ReturnsAlreadyShootStatus()
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            var scoreRepositoryMock = new Mock<IRepository<Score>>();
            scoreRepositoryMock.SetupGet(c => c.Entity).Returns(new Score());
            var mapWithShips = new Map(10, 10);
            var ship = CreateShipWithCoordinates();
            AssignShipToMap(mapWithShips, ship);
            mapRepoMock.SetupGet(c => c.Entity).Returns(mapWithShips);
            var battleService = new BattleService(mapRepoMock.Object, scoreRepositoryMock.Object);

            battleService.Shoot(0, 1);
            var result = battleService.Shoot(0, 1);
            result.LastShootStatus.Should().BeEquivalentTo(ShootStatus.AlreadyShoot);
        }

        [Test]
        public void Shoot_WHEN_InvokedWithOutOfRange_THEN_ThrowsOutOfRangeException()
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            var scoreRepositoryMock = new Mock<IRepository<Score>>();
            var mapWithShips = new Map(10, 10);
            mapRepoMock.SetupGet(c => c.Entity).Returns(mapWithShips);
            var battleService = new BattleService(mapRepoMock.Object, scoreRepositoryMock.Object);

            var act = new Func<ShootResult>(() => battleService.Shoot(10, 2));
            act.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Shoot_WHEN_InvokedAndNoMapFound_THEN_ThrowsMapNotInitializedException()
        {
            var mapRepoMock = new Mock<IRepository<Map>>();
            var scoreRepositoryMock = new Mock<IRepository<Score>>();
            mapRepoMock.SetupGet(c => c.Entity).Returns((Map)null);
            var battleService = new BattleService(mapRepoMock.Object, scoreRepositoryMock.Object);

            var act = new Func<ShootResult>(() => battleService.Shoot(10, 2));
            act.Should().ThrowExactly<MapNotInitializedException>();
        }

        private static Ship CreateShipWithCoordinates()
        {
            var ship = new Ship(4)
            {
                Coordinates =
                {
                    new Coordinates(0, 1) {IsHit = true},
                    new Coordinates(0, 2) {IsHit = true},
                    new Coordinates(0, 3) {IsHit = true},
                    new Coordinates(0, 4) {IsHit = false}
                }
            };
            return ship;
        }
        private static void AssignShipToMap(Map mapWithShips, Ship ship)
        {
            foreach (var shipCoordinate in ship.Coordinates)
            {
                mapWithShips.Fields[shipCoordinate.Row][shipCoordinate.Column].Ship = ship;
            }
        }

    }

}

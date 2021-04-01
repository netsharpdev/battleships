using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Services;
using BattleShips.Core.Repositories;
using BattleShips.Core.Services;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace BattleShips.Tests.Unit
{
    public class MapServiceTests
    {
        [Test]
        public void CreateMap_WHEN_InvokedWithPositiveParameters_THEN_ReturnMapWithRowsAndColumnsAsProvided()
        {
            var mapRepository = new InMemoryMapRepository();
            IMapService mapService = new MapService(mapRepository);
            var rows = 10;
            var columns = 10;
            var expectedFieldsNumber = rows * columns;
            var map = mapService.CreateMap(rows, columns);

            map.Fields.Should().NotBeNull();
            map.Fields.SelectMany(c => c).Count().Should().Be(expectedFieldsNumber);
        }

        [Test]
        public void CreateMap_WHEN_InvokedWithPositiveParameters_THEN_ReturnMapFieldsWithDefaultState()
        {
            var mapRepository = new InMemoryMapRepository();
            IMapService mapService = new MapService(mapRepository);
            var rows = 10;
            var columns = 10;
            var map = mapService.CreateMap(rows, columns);

            map.Fields.Should().NotBeNull();
            map.Fields.SelectMany(c => c).Select(c => c.IsShoot).Should().AllBeEquivalentTo(false);
            map.Fields.SelectMany(c => c).Select(c => c.Ship).Should().AllBeEquivalentTo((Ship) null);
        }

        [TestCase(10, -1)]
        [TestCase(0, 2)]
        [TestCase(-1, -2)]
        public void CreateMap_WHEN_InvokedWithAtLeastOneNegativeOrZeroParameter_THEN_ThrowArgumentOutOfRangeException(
            int columns,
            int rows)
        {
            var mapRepository = new InMemoryMapRepository();
            IMapService mapService = new MapService(mapRepository);
            var action = new Func<Map>(() => mapService.CreateMap(rows, columns));

            action.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }


    }
}

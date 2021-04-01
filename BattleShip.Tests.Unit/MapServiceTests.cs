using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Core.Abstractions.Services;
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
            IMapService mapService = new MapService();
            var rows = 10;
            var columns = 10;
            var expectedFieldsNumber = rows * columns;
            var map = mapService.CreateMap(rows, columns);

            map.Fields.Should().NotBeNull();
            map.Fields.SelectMany(c=>c).Count().Should().Be(expectedFieldsNumber);
        }
        [Test]
        public void CreateMap_WHEN_InvokedWithPositiveParameters_THEN_ReturnMapFieldsWithDefaultState()
        {
            IMapService mapService = new MapService();
            var rows = 10;
            var columns = 10;
            var map = mapService.CreateMap(rows, columns);

            map.Fields.Should().NotBeNull();
            map.Fields.SelectMany(c => c).Select(c=>c.IsShoot).Should().AllBeEquivalentTo(false);
            map.Fields.SelectMany(c=>c).Select(c => c.Ship).Should().AllBeEquivalentTo((Ship)null);
        }
        [TestCase(10, -1)]
        [TestCase(0, 2)]
        [TestCase(-1, -2)]
        public void CreateMap_WHEN_InvokedWithAtLeastOneNegativeOrZeroParameter_THEN_ThrowArgumentOutOfRangeException(int columns, int rows)
        {
            IMapService mapService = new MapService();
            var action = new Func<Map>(()=> mapService.CreateMap(rows, columns));

            action.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Test]
        public void DrawMap_WHEN_InvokedWithMapWithoutShoots_THEN_ReturnMapConvertedToStringWithProperChars()
        {
            IMapService mapService = new MapService();
            var map = mapService.CreateMap(10, 10);
            var textMap = mapService.DrawMap(map);

            textMap.Length.Should().BePositive();
            textMap.Should().NotContain("x");
            textMap.Should().NotContain("o");
            textMap.Should().Contain("+");

        }
        [Test]
        public void DrawMap_WHEN_InvokedWithMapWitShoots_THEN_ReturnMapConvertedToStringWithProperChars()
        {
            IMapService mapService = new MapService();
            var map = mapService.CreateMap(10, 10);
            map.Fields[1][1].IsShoot = true;
            var textMap = mapService.DrawMap(map);

            textMap.Length.Should().BePositive();
            textMap.Should().NotContain("x");
            textMap.Should().NotContain("o");
            textMap.Should().Contain("+");

        }
        [Test]
        public void DrawMap_WHEN_InvokedWithNull_THEN_ThrowArgumentNullException()
        {
            IMapService mapService = new MapService();
            var action = new Func<string>(()=> mapService.DrawMap(null));
            action.Should().ThrowExactly<ArgumentNullException>();

        }


    }
}

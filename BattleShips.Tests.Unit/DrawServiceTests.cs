using System;
using BattleShips.Core.Abstractions.Models;
using BattleShips.Services;
using FluentAssertions;
using NUnit.Framework;

namespace BattleShips.Tests.Unit
{
    public class DrawServiceTests
    {
        [Test]
        public void DrawMap_WHEN_InvokedWithMapWithoutShoots_THEN_ReturnMapConvertedToStringWithProperChars()
        {
            IDrawService drawService = new DrawService();
            var map = new Map(10, 10);
            var textMap = drawService.DrawMap(map);

            textMap.Length.Should().BePositive();
            textMap.Should().NotContain("x");
            textMap.Should().NotContain("o");
            textMap.Should().Contain("+");

        }

        [Test]
        public void DrawMap_WHEN_InvokedWithMapWitShoots_THEN_ReturnMapConvertedToStringWithProperChars()
        {
            IDrawService drawService = new DrawService();
            var map = new Map(10, 10);
            map.Fields[1][1].IsShoot = true;
            var textMap = drawService.DrawMap(map);

            textMap.Length.Should().BePositive();
            textMap.Should().NotContain("x");
            textMap.Should().Contain("o");
            textMap.Should().Contain("+");

        }

        [Test]
        public void DrawMap_WHEN_InvokedWithNull_THEN_ThrowArgumentNullException()
        {
            IDrawService drawService = new DrawService();
            var action = new Func<string>(() => drawService.DrawMap(null));
            action.Should().ThrowExactly<ArgumentNullException>();

        }
    }
}
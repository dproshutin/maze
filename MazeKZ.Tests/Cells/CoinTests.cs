﻿using MazeKZ.Cells;
using Moq;
using NUnit.Framework;
using System;

namespace MazeKZ.Tests.Cells
{
    public class CoinTests
    {
        [Test]

        public void TryStep_Coin()
        {
            Mock<Maze> mazeMock = new Mock<Maze>();
            Maze maze = mazeMock.Object;

            Mock<Hero> heroMock = new Mock<Hero>();
            heroMock.SetupAllProperties();

            Hero hero = heroMock.Object;
            hero.Money = 0;

            mazeMock.Setup(x => x.Hero).Returns(hero);
            var coin = new Coin(1, 1, maze);
            
            var answer = coin.TryStep();

            Assert.AreEqual(1, hero.Money);
            mazeMock.Verify(x => x.ReplaceToGround(coin), Times.Once);
            Assert.AreEqual(true, answer);
        }
    }
}

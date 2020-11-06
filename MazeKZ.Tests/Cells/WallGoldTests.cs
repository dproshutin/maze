using MazeKZ.Cells;
using Moq;
using NUnit.Framework;
using System;

namespace MazeKZ.Tests.Cells
{
    public class WallGoldTests
    {
        [Test]
        [TestCase(1, 1, false)]
        [TestCase(2, 2, false)]
        [TestCase(3, 3, true)]

        public void TryStep_WallGold(int countOfAttempt, int coinCount, bool wallWasBroken)
        {
            // Data Preparation
            Mock<Maze> mazeMock = new Mock<Maze>();
            Maze maze = mazeMock.Object;

            Mock<Hero> heroMock = new Mock<Hero>();
            heroMock.SetupAllProperties();

            Hero hero = heroMock.Object;
            hero.Money = 0;

            mazeMock.Setup(x => x.Hero).Returns(hero);
            var wallGold = new WallGold(1, 1, maze);

            //Action
            bool answer = false;
            for (int i = 0; i < countOfAttempt; i++)
            {
                answer = wallGold.TryStep();
            }

            // Checks
            Assert.AreEqual(coinCount, hero.Money);
            if (wallWasBroken)
            {
                mazeMock.Verify(x => x.ReplaceToGround(wallGold), Times.Once);
                Assert.AreEqual(true, answer);
            }
            else
            {
                Assert.AreEqual(false, answer);
            }

        }
    }
}

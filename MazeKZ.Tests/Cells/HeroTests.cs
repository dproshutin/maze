using MazeKZ.Cells;
using NUnit.Framework;
using System;

namespace MazeKZ.Tests.Cells
{
    public class HeroTests
    {
        [Test]

        public void TryStep_Hero()
        {
            // data preparation
            var hero = new Hero(1, 1, null);

            // action
            // checks
            Assert.Throws<NotImplementedException>(() => hero.TryStep());
        }
    }
}

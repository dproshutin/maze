using MazeKZ.Cells;
using NUnit.Framework;
using System;

namespace MazeKZ.Tests.Cells
{
    public class WallTests
    {
        [Test]

        public void TryStep_Wall()
        {
            var wall = new Wall(1, 1, null);
            
            var answer = wall.TryStep();

            Assert.AreEqual(false, answer);
        }
    }
}

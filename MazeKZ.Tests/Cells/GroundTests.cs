using MazeKZ.Cells;
using NUnit.Framework;
using System;

namespace MazeKZ.Tests.Cells
{
    public class GroundTests
    {
        [Test]

        public void TryStep_Ground()
        {
            // data preparation
            var ground = new Ground(1, 1, null);
            
            // action
            var answer = ground.TryStep();

            // checks
            Assert.AreEqual(true, answer);
        }
    }
}

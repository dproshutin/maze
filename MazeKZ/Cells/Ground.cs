using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKZ.Cells
{
    public class Ground : CellBase
    {
        public Ground(int x, int y, Maze maze) : base(x, y, maze)
        {

        }

        public override bool TryStep()
        {
            return true;
        }
    }
}
    
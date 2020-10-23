﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKZ.Cells
{
    public class Cell
    {
        public Cell(int x, int y, CellType cellType)
        {
            X = x;
            Y = y;
            CellType = cellType;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public CellType CellType { get; set; }

        public override string ToString()
        {
            return $"[{X},{Y}]{CellType.ToString()}";
        }
    }
}
    
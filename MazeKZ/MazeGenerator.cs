using MazeKZ.Cells;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace MazeKZ
{
    public class MazeGenerator
    {
        private Random _random = new Random();
        private Maze _maze;

        public Maze GenerateRandom(int width = 10, int height = 5)
        {
            var maze = new Maze
            {
                Width = width,
                Height = height
            };

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var number = _random.Next(1, 4);

                    var cellType = (CellType)number;
                    var cell = new Cell(x, y, cellType);
                    maze.Cells.Add(cell);
                }
            }
            return maze;
        }
        public Maze GenerateSmart(int width = 10, int height = 5)
        {


            // maze that solely consists of walls is created
            _maze = GenerateMazeFullWall(width, height);

            // coordinates of the shaftman
            var minerX = 0;
            var minerY = 0;

            List<Cell> cellsAllowToBreak = new List<Cell>();
            do
            {
                //DrawMaze();
                // break a wall where the shaftman is located
                BreakWall(minerX, minerY);
                var brokenWall = cellsAllowToBreak.SingleOrDefault(x => x.X == minerX && x.Y == minerY);
                if (brokenWall != null)
                {
                    cellsAllowToBreak.Remove(brokenWall);
                }
                

                // select all cells that are near the shaftman
                var nearCells = GetNearCells(minerX, minerY, CellType.Wall);
                cellsAllowToBreak.AddRange(nearCells);
                cellsAllowToBreak  = cellsAllowToBreak
                    .Where(wall => GetNearCells(wall.X, wall.Y, CellType.Ground).Count() <= 1)
                    .Distinct()
                    .ToList();

                // select a random cell where the shaftman goes to
                var randomCell = GetRandomCell(cellsAllowToBreak);
                minerX = randomCell?.X ?? 0;
                minerY = randomCell?.Y ?? 0;
            } while (cellsAllowToBreak.Any()) ;

            return _maze;
        }

        private void DrawMaze()
        {
            var drawer = new Drawer();
            drawer.DrawMaze(_maze);
            Console.WriteLine("--------------------------------------");
            Thread.Sleep(200);
        }

        private Cell GetRandomCell(List<Cell> nearCells)
        {
            if (!nearCells.Any())
            {
                return null;
            }
            var randomIndex = _random.Next(0, nearCells.Count);
            return nearCells[randomIndex];
        }

        private List<Cell> GetNearCells(int minerX, int minerY, CellType type)
        {
            var nearCells = new List<Cell>()
                {
                    _maze[minerX - 1, minerY],
                    _maze[minerX + 1, minerY],
                    _maze[minerX, minerY - 1],
                    _maze[minerX, minerY + 1]
                };
            nearCells = nearCells
                .Where(x => x != null && x.CellType == type)
                .ToList();
            return nearCells;
        }

        private void BreakWall(int minerX, int minerY)
        {
            var cell = _maze[minerX, minerY];
            cell.CellType = CellType.Ground;
        }

        private Maze GenerateMazeFullWall(int width, int height)
        {
            var maze = new Maze
            {
                Width = width,
                Height = height
            };

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    maze.Cells.Add(new Cell(x, y, CellType.Wall));
                }
            }

            return maze;
        }
    }
}

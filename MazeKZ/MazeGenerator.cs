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

        public Maze GenerateSmart(int width = 10, int height = 5)
        {


            // maze that solely consists of walls is created
            _maze = GenerateMazeFullWall(width, height);

            // coordinates of the shaftman
            var minerX = 0;
            var minerY = 0;

            GenerateWall(minerX, minerY);

            _maze.Hero = new Hero(0, 0, _maze);
            GenerateCoin();
            return _maze;
        }

        private void GenerateWall(int minerX, int minerY)
        {
            List<CellBase> cellsAllowToBreak = new List<CellBase>();
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
                var nearCells = GetNearCells<Wall>(minerX, minerY);
                cellsAllowToBreak.AddRange(nearCells);
                cellsAllowToBreak = cellsAllowToBreak
                    .Where(wall => GetNearCells<Ground>(wall.X, wall.Y).Count() <= 1)
                    .Distinct()
                    .ToList();

                // select a random cell where the shaftman goes to
                var randomCell = GetRandomCell(cellsAllowToBreak);
                minerX = randomCell?.X ?? 0;
                minerY = randomCell?.Y ?? 0;
            } while (cellsAllowToBreak.Any());
        }

        private void DrawMaze()
        {
            var drawer = new Drawer();
            drawer.DrawMaze(_maze);
            Console.WriteLine("--------------------------------------");
            Thread.Sleep(200);
        }

        private void GenerateCoin()
        {
            var grounds = _maze.Cells.OfType<Ground>().ToList();

            for (int i = 0; i < 10; i++)
            {
                var randomGround = GetRandomCell(grounds);
                var coin = new Coin(randomGround.X, randomGround.Y, _maze);
                _maze.ReplaceCell(coin);
            }
        }

        private CellBase GetRandomCell(IEnumerable<CellBase> nearCells)
        {
            if (!nearCells.Any())
            {
                return null;
            }
            var list = nearCells.ToList();
            var randomIndex = _random.Next(0, list.Count);
            return list[randomIndex];
        }

        private IEnumerable<CellBase> GetNearCells<T>(int minerX, int minerY) where T : CellBase
        {
            var nearCells = new List<CellBase>()
                {
                    _maze[minerX - 1, minerY],
                    _maze[minerX + 1, minerY],
                    _maze[minerX, minerY - 1],
                    _maze[minerX, minerY + 1]
                };
            var answer = nearCells
                .Where(x => x != null)
                .OfType<T>();
            return answer;
        }

        private void BreakWall(int minerX, int minerY)
        {
            var ground = new Ground(minerX, minerY, _maze);
            _maze.ReplaceCell(ground);
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
                    maze.Cells.Add(new Wall(x, y, maze));
                }
            }

            return maze;
        }
    }
}

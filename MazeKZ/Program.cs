using System;

namespace MazeKZ
{
    class Program
    {
        static void Main(string[] args)
        {
            var mazeGenerator = new MazeGenerator();
            var maze = mazeGenerator.GenerateSmart(30, 30);
            var draw = new Drawer();
            draw.DrawMaze(maze);
        }
    }
}

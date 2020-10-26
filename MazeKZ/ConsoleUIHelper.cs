using System;
using System.Collections.Generic;
using System.Text;
using MazeKZ.CustomExceptions;

namespace MazeKZ
{
    class ConsoleUIHelper
    {
        public void ConfigurateMaze()
        {
            var width = ReadInt("Какой ширины должен быть лабиринт?");
            var height = ReadInt("А какой он должен быть высоты?");


            var mazeGenerator = new MazeGenerator();
            var maze = mazeGenerator.GenerateSmart(width, height);

            Play(maze);
        }
        public void Play(Maze maze)
        {
            var draw = new Drawer();
            draw.DrawMaze(maze);

            var continuePlay = true;
            while (continuePlay)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        maze.TryToStep(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        maze.TryToStep(Direction.Right);
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        maze.TryToStep(Direction.Top);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        maze.TryToStep(Direction.Bottom);
                        break;
                    case ConsoleKey.Escape:
                        continuePlay = false;
                        break;
                }

                draw.DrawMaze(maze);
            }

            Console.WriteLine("Goodbye");
        }

        public int ReadInt(string message)
        {
            Console.WriteLine(message);
            var str = Console.ReadLine();
            var number = -1;

            number = Int32.Parse(str);
            while(!Int32.TryParse(str, out number) || number < 0)
            {
                Console.WriteLine("Это было не число, ну или оно было слишком маленькое.");
                Console.WriteLine("Нужно число больше 0. Попробуй еще раз.");
                str = Console.ReadLine();
            }
            return number;
        }
    }
}

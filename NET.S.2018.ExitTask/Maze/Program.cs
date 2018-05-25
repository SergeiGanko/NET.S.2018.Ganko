using System;
using Maze.Logic;

namespace Maze
{
    internal sealed class Program
    {
        private static void Main()
        {
            int[,] mazeArray =
                {
                    { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
                    {  0,  0, -1,  0,  0,  0,  0,  0, -1,  0,  0, -1 },
                    { -1,  0, -1,  0, -1, -1,  0,  0, -1, -1,  0, -1 },
                    { -1,  0, -1,  0,  0, -1,  0,  0,  0,  0,  0, -1 },
                    { -1,  0, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1 },
                    { -1,  0, -1,  0,  0, -1,  0, -1,  0,  0,  0, -1 },
                    { -1,  0, -1,  0, -1, -1,  0,  0,  0, -1,  0, -1 },
                    { -1,  0, -1,  0,  0,  0,  0, -1, -1, -1,  0, -1 },
                    { -1,  0, -1,  0, -1,  0,  0, -1,  0, -1,  0, -1 },
                    { -1,  0, -1, -1, -1, -1,  0, -1,  0, -1,  0, -1 },
                    { -1,  0,  0,  0,  0,  0,  0, -1,  0,  0,  0, -2 },
                    { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
                };

            var maze = new MazeSolver(mazeArray, 0, 1);

            MazePrinter.Print(mazeArray);

            if (maze.FindWay())
            {
                Console.WriteLine("\nMaze passed");
                MazePrinter.Print(maze.GetMaze);
            }
            else
            {
                Console.WriteLine("Can't find any way");
            }

            Console.WriteLine();

            var mazeArray1 = new int[,]
                            {
                                { -1, -1, -1, -1,  0, -1 },
                                { -2,  0,  0, -1,  0, -1 },
                                { -1,  0, -1, -1,  0, -1 },
                                { -1,  0, -1,  0,  0,  0 },
                                { -1,  0,  0,  0, -1, -1 },
                                { -1, -1, -1, -1, -1, -1 }
                            };

            maze = new MazeSolver(mazeArray1, 0, 4);

            MazePrinter.Print(mazeArray1);

            if (maze.FindWay())
            {
                Console.WriteLine("\nMaze passed");
                MazePrinter.Print(maze.GetMaze);
            }
            else
            {
                Console.WriteLine("Can't find any way");
            }
        }
    }
}

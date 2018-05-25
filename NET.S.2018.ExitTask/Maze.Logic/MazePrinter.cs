using System;

namespace Maze.Logic
{
    public static class MazePrinter
    {
        /// <summary>
        /// Prints the specified maze.
        /// </summary>
        /// <param name="maze">The maze.</param>
        public static void Print(int[,] maze)
        {
            if (ReferenceEquals(maze, null))
            {
                throw new ArgumentNullException($"Argument {nameof(maze)} is null");
            }

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write($" {maze[i, j],3} ");
                }

                Console.WriteLine();
            }
        }
    }
}

using System;

namespace Maze
{
    /// <summary>
    /// Class Program
    /// </summary>
    internal sealed class Program
    {
        private const int mazeSize = 12;
        private const int maxAllowedMoves = 4;
        private static readonly int[] allowedMoveRow = { 0, -1, 0, 1 };
        private static readonly int[] allowedMoveCol = { 1, 0, -1, 0 };

        // 0 - start, -2 - exit
        private static readonly int[,] maze = new int[mazeSize, mazeSize]
        {
            {  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
            {   0,  0, -1,  0,  0,  0,  0,  0, -1,  0,  0, -1 },
            {  -1,  0, -1,  0, -1, -1,  0,  0, -1, -1,  0, -1 },
            {  -1,  0, -1,  0,  0, -1,  0,  0,  0,  0,  0, -1 },
            {  -1,  0, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1 },
            {  -1,  0, -1,  0,  0, -1,  0, -1,  0,  0,  0, -1 },
            {  -1,  0, -1,  0, -1, -1,  0,  0,  0, -1,  0, -1 },
            {  -1,  0, -1,  0,  0,  0,  0, -1, -1, -1,  0, -1 },
            {  -1,  0, -1,  0, -1,  0,  0, -1,  0, -1,  0, -1 },
            {  -1,  0, -1, -1, -1, -1,  0, -1,  0, -1,  0, -1 },
            {  -1,  0,  0,  0,  0,  0,  0, -1,  0,  0,  0, -2 },
            {  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
        };

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            Print(maze);

            Console.WriteLine("Finding a way...");

            if (FindWay(0, 1, 1))
            {
                Print(maze);
            }
            else
            {
                Console.WriteLine("Can't find any way");
            }
        }

        /// <summary>
        /// Finds a way through the maze.
        /// </summary>
        /// <param name="previousRow">The previous row.</param>
        /// <param name="previousCol">The previous column.</param>
        /// <param name="nextStep">The next step.</param>
        /// <returns>Returns true if a way has been found, and false if a way not found</returns>
        private static bool FindWay(int previousRow, int previousCol, int nextStep)
        {
            for (int i = 0; i < maxAllowedMoves; i++)
            {
                int column = previousCol + allowedMoveCol[i];
                int row = previousRow + allowedMoveRow[i];

                if (column < 0 || column >= mazeSize)
                {
                    continue;
                }
                    
                if (row < 0 || row >= mazeSize)
                {
                    continue;
                }

                if (maze[row, column] == -2)
                {
                    return true;
                } 

                if (maze[row, column] != 0)
                {
                    continue;
                }
                    
                maze[row, column] = nextStep;

                if (FindWay(row, column, nextStep + 1))
                {
                    return true;
                }
                else
                {
                    maze[row, column] = 0;
                }
            }

            return false;
        }

        /// <summary>
        /// Prints the specified maze.
        /// </summary>
        /// <param name="maze">The maze.</param>
        private static void Print(int[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write($" {maze[i, j], 3} ");
                }

                Console.WriteLine();
            }
        }
    }
}

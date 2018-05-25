using System;

namespace Maze.Logic
{
    public class MazeSolver
    {
        #region Consts

        private const int maxAllowedMoves = 4;

        private static readonly int[] allowedMoveRow = { 0, -1, 0, 1 };

        private static readonly int[] allowedMoveCol = { 1, 0, -1, 0 };

        #endregion

        #region Fields

        private readonly int[,] maze;

        private readonly int startX;

        private readonly int startY;

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeSolver"/> class.
        /// </summary>
        /// <param name="maze">The maze.</param>
        /// <param name="startX">The start index x.</param>
        /// <param name="startY">The start y.</param>
        /// <exception cref="ArgumentNullException">Throws when argument is null</exception>
        /// <exception cref="ArgumentException">Throws when startX or startY is below zero</exception>
        public MazeSolver(int[,] maze, int startX, int startY)
        {
            if (ReferenceEquals(maze, null))
            {
                throw new ArgumentNullException($"Argument {nameof(maze)} is null");
            }

            if (startX < 0)
            {
                throw new ArgumentException($"Argument {nameof(startX)} must be greater than 0.");
            }

            if (startY < 0)
            {
                throw new ArgumentException($"Argument {nameof(startY)} must be greater than 0.");
            }

            this.maze = maze;
            this.startX = startX;
            this.startY = startY;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the get maze.
        /// </summary>
        public int[,] GetMaze => this.maze;

        /// <summary>
        /// Finds a way through the maze.
        /// </summary>
        /// <returns></returns>
        public bool FindWay()
        {
            return this.FindWay(startX, startY, 1);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Finds a way through the maze.
        /// </summary>
        /// <param name="previousRow">The previous row.</param>
        /// <param name="previousCol">The previous column.</param>
        /// <param name="nextStep">The next step.</param>
        /// <returns>Returns true if a way has been found, and false if a way not found</returns>
        private bool FindWay(int previousRow, int previousCol, int nextStep)
        {
            for (int i = 0; i < maxAllowedMoves; i++)
            {
                int column = previousCol + allowedMoveCol[i];
                int row = previousRow + allowedMoveRow[i];

                if (column < 0 || column >= this.maze.GetLength(0))
                {
                    continue;
                }

                if (row < 0 || row >= this.maze.GetLength(0))
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

        #endregion
    }
}

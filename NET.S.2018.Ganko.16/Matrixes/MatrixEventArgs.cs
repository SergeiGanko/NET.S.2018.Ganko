using System;

namespace Matrixes
{
    /// <summary>
    /// Class MatrixEventArgs
    /// </summary>
    public sealed class MatrixEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixEventArgs{T}"/> class.
        /// </summary>
        /// <param name="oldElement">The old element of a matrix.</param>
        /// <param name="newElement">The new element of a matrix.</param>
        /// <param name="row">The row of the changed element.</param>
        /// <param name="column">The column of the changed element.</param>
        public MatrixEventArgs(T oldElement, T newElement, int row, int column)
        {
            OldElement = oldElement;
            NewElement = newElement;
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Gets the row.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Gets the new element.
        /// </summary>
        public T NewElement { get; }

        /// <summary>
        /// Gets the old element.
        /// </summary>
        public T OldElement { get; }
    }
}

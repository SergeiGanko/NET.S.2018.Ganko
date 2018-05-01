using System;
using System.Linq;
using System.Collections.Generic;

namespace Matrixes
{
    /// <summary>
    /// Class represents a square matrix
    /// </summary>
    public sealed class SquareMatrix<T> : Matrix<T>
    {
        #region Fields

        /// <summary>
        /// The matrix
        /// </summary>
        private readonly T[][] matrix;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public SquareMatrix(int order) : base(order)
        {
            this.matrix = new T[order][];

            for (int i = 0; i < Order; i++)
            {
                this.matrix[i] = new T[Order];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public SquareMatrix(T[][] matrix) : base(matrix)
        {
            this.matrix = matrix;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        public SquareMatrix(IEnumerable<T> sequence) : base(sequence)
        {
            this.matrix = new T[Order][];

            for (int i = 0; i < Order; i++)
            {
                this.matrix[i] = new T[Order];
            }

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    SetElement(sequence.ElementAt((i * this.Order) + j), i, j);
                }
            }
        }

        #endregion

        #region Public Members

        #endregion

        #region Protected Members

        /// <summary>
        /// Gets the element at the specified indexes.
        /// </summary>
        /// <param name="i">The index i.</param>
        /// <param name="j">The index j.</param>
        /// <returns>
        /// Returns element of the matrix
        /// </returns>
        protected override T GetElement(int i, int j) => matrix[i].ElementAt(j);

        /// <summary>
        /// Sets the element at the specified indexes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The index i.</param>
        /// <param name="j">The index j.</param>
        protected override void SetElement(T value, int i, int j) => matrix[i].SetValue(value, j);

        #endregion

        #region Private Members



        #endregion
    }
}

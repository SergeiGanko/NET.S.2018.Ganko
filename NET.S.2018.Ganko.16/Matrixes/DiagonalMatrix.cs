using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrixes
{
    /// <summary>
    /// Class represents diagonal matrix
    /// </summary>
    public sealed class DiagonalMatrix<T> : Matrix<T>
    {
        #region Fields

        /// <summary>
        /// The main diagonal
        /// </summary>
        private readonly T[] mainDiagonal;

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="order">The order of a matrix.</param>
        public DiagonalMatrix(int order) : base(order)
        {
            this.mainDiagonal = new T[order];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <exception cref="ArgumentNullException">Throws when the sequence is null</exception>
        public DiagonalMatrix(IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException($"Argument {nameof(sequence)} is null");
            }

            Order = sequence.Count();
            
            this.mainDiagonal = new T[Order];

            for (int i = 0; i < Order; i++)
            {
                this.mainDiagonal[i] = sequence.ElementAt(i);
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
        protected override T GetElement(int i, int j)
        {
            return i != j ? default(T) : this.mainDiagonal[i];
        }

        /// <summary>
        /// Sets the element at the specified indexes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The index i.</param>
        /// <param name="j">The index j.</param>
        /// <exception cref="NotSupportedException">The non-diagonal elements is immutable</exception>
        protected override void SetElement(T value, int i, int j)
        {
            if (i != j)
            {
                throw new NotSupportedException("The non-diagonal elements is immutable");
            }

            this.mainDiagonal[i] = value;
        }

        #endregion
    }
}

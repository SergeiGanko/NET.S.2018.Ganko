using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Matrixes
{
    /// <summary>
    /// Abstract class represents a common square matrix 
    /// </summary>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        #region Constatants

        /// <summary>
        /// The default order of matrix
        /// </summary>
        private const int defaultOrder = 1;

        #endregion

        #region Fields

        /// <summary>
        /// Occurs when element in matrix is changed.
        /// </summary>
        public event EventHandler<MatrixEventArgs<T>> ElementChanged = delegate { };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        protected Matrix()
        {
            Order = defaultOrder;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <exception cref="ArgumentException">Throws when order is below zero</exception>
        protected Matrix(int order)
        {
            if (order < 1)
            {
                throw new ArgumentException($"Argument {nameof(order)} must be greater then zero");
            }

            Order = order;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentNullException">Throws when matrix is null</exception>
        /// <exception cref="ArgumentException">Throws when the matrix isn't square</exception>
        protected Matrix(T[][] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"Argument {nameof(matrix)} is null");
            }

            if (matrix[0].Length != matrix.Count())
            {
                throw new ArgumentException($"The matrix isn't square matrix");
            }

            Order = matrix[0].Length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <exception cref="ArgumentNullException">Throws when the sequence is null</exception>
        /// <exception cref="ArgumentException">Throws when sequence contains incorrect number of elements</exception>
        protected Matrix(IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException($"Argument {nameof(sequence)} is null");
            }

            Order = (int)Math.Sqrt(sequence.Count());

            if (sequence.Count() != Math.Pow(Order, 2))
            {
                throw new ArgumentException($"Can't create a square matrix from the sequence. Incorrect number of elements in the sequence.");
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the order of matrix.
        /// </summary>
        public int Order { get; protected set; }

        /// <summary>
        /// Gets or sets the element at the specified indexes.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>Returns the element which located in the matrix at specified indexes</returns>
        public T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                return GetElement(i, j);
            }
            set
            {
                CheckIndexes(i, j);
                var oldElement = GetElement(i, j);
                SetElement(value, i, j);
                OnElementChanged(this, new MatrixEventArgs<T>(oldElement, value, i, j));
            }
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the matrix.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the matrix.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a matrix.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the matrix.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Gets the element at the specified indexes.
        /// </summary>
        /// <param name="i">The index i.</param>
        /// <param name="j">The index j.</param>
        /// <returns>Returns element of the matrix</returns>
        protected abstract T GetElement(int i, int j);

        /// <summary>
        /// Sets the element at the specified indexes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The index i.</param>
        /// <param name="j">The index j.</param>
        protected abstract void SetElement(T value, int i, int j);

        /// <summary>
        /// Called when element of the matrix is changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MatrixEventArgs{T}"/> instance containing the event data.</param>
        protected virtual void OnElementChanged(object sender, MatrixEventArgs<T> e)
        {
            EventHandler<MatrixEventArgs<T>> temp = ElementChanged;
            temp?.Invoke(sender, e);
        }

        /// <summary>
        /// Method checks the indexes.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws when indexes is out of range
        /// </exception>
        protected void CheckIndexes(int i, int j)
        {
            if (i < 0 || i > Order)
            {
                throw new ArgumentOutOfRangeException($"Index {nameof(i)} is out of range");
            }

            if (j < 0 || j > Order)
            {
                throw new ArgumentOutOfRangeException($"Index {nameof(j)} is out of range");
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrixes
{
    /// <summary>
    /// Class represents a symetric matrix
    /// </summary>
    public sealed class SymentricMatrix<T> : Matrix<T>
    {
        #region Fields

        /// <summary>
        /// The matrix
        /// </summary>
        private readonly T[][] matrix;

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="SymentricMatrix{T}"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public SymentricMatrix(int order) : base(order)
        {
            this.matrix = new T[order][];

            for (int i = 0; i < order; i++)
            {
                this.matrix[i] = new T[order - i];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymentricMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="ArgumentException">Throws when the input matrix isn't symetric</exception>
        public SymentricMatrix(T[][] matrix) : base(matrix)
        {
            if (!IsSymetricMatrix(matrix))
            {
                throw new ArgumentException("The input matrix isn't symetric");
            }

            this.matrix = matrix;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymentricMatrix{T}"/> class.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <exception cref="ArgumentException">Throws when the matrix isn't symetric</exception>
        public SymentricMatrix(IEnumerable<T> sequence) : base(sequence)
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

            if (!IsSymetricMatrix(this.matrix))
            {
                throw new ArgumentException("The matrix isn't symetric");
            }
        }

        #endregion

        #region PublicMembers

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

        /// <summary>
        /// Determines whether the matrix is symetric matrix.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <returns>
        ///   <c>true</c> if the matrix is symetric matrix; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsSymetricMatrix(T[][] jaggedArray)
        {
            var array = JaggedArrayToTwoDimensionalArray(jaggedArray);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!array[i, j].Equals(array[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Converts jagged array to two dimensional array.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <returns>Returns two dimensional array</returns>
        private static T[,] JaggedArrayToTwoDimensionalArray(T[][] jaggedArray)
        {
            int order = jaggedArray[0].Length;
            var matrix = new T[order, order];

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    matrix[i, j] = jaggedArray[i].ElementAt(j);
                }
            }

            return matrix;
        }

        #endregion
    }
}

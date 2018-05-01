using System;

namespace Matrixes
{
    /// <summary>
    /// Class ComputeSumVisitor
    /// </summary>
    public sealed class ComputeSumVisitor<T> : MatrixVisitor<T>
    {
        /// <summary>
        /// The other matrix
        /// </summary>
        private readonly Matrix<T> other;

        /// <summary>
        /// The rule which determines operation of addition
        /// </summary>
        private readonly Func<T, T, T> rule;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComputeSumVisitor{T}"/> class.
        /// </summary>
        /// <param name="other">The other marix.</param>
        /// <param name="rule">The rule which determines operation of addition.</param>
        public ComputeSumVisitor(Matrix<T> other, Func<T, T, T> rule)
        {
            this.other = other;
            this.rule = rule;
        }

        /// <summary>
        /// Gets the result of the matrices addition.
        /// </summary>
        public SquareMatrix<T> Result { get; private set; }

        /// <summary>
        /// Calls the Add method with the specified diagonal matrix.
        /// </summary>
        /// <param name="diagonal">The diagonal matrix.</param>
        /// <returns>Returns a square matrix which obtained as a result of addition of two matrices</returns>
        public override SquareMatrix<T> Visit(DiagonalMatrix<T> diagonal)
        {
            return Add(diagonal);
        }

        /// <summary>
        /// Calls the Add method with the specified square matrix.
        /// </summary>
        /// <param name="square">The square.</param>
        /// <returns>Returns a square matrix which obtained as a result of addition of two matrices</returns>
        public override SquareMatrix<T> Visit(SquareMatrix<T> square)
        {
            return Add(square);
        }

        /// <summary>
        /// Calls the Add method with the specified symetric matrix.
        /// </summary>
        /// <param name="symetric">The symetric.</param>
        /// <returns>Returns a square matrix which obtained as a result of addition of two matrices</returns>
        public override SquareMatrix<T> Visit(SymentricMatrix<T> symetric)
        {
            return Add(symetric);
        }

        /// <summary>
        /// Adds the specified matrices.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>Returns a square matrix which obtained as a result of addition of two matrices</returns>
        /// <exception cref="ArgumentNullException">Throws when matrix is null</exception>
        /// <exception cref="ArgumentException">Throws when matrices has different order</exception>
        private SquareMatrix<T> Add(Matrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"Argument {nameof(matrix)} is null");
            }

            if (matrix.Order != this.other.Order)
            {
                throw new ArgumentException($"Matrices has different order");
            }

            Result = new SquareMatrix<T>(matrix.Order);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Result[i, j] = this.rule(matrix[i, j], this.other[i, j]);
                }
            }

            return Result;
        }
    }
}

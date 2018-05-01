namespace Matrixes
{
    /// <summary>
    /// Abstract class MatrixVisitor
    /// </summary>
    public abstract class MatrixVisitor<T>
    {
        /// <summary>
        /// Determines which matrix to call at the runtime
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public void DynamicVisit(Matrix<T> matrix) => Visit((dynamic)matrix);

        /// <summary>
        /// Visits the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>Returns a square matrix</returns>
        public abstract SquareMatrix<T> Visit(DiagonalMatrix<T> matrix);

        /// <summary>
        /// Visits the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>Returns a square matrix</returns>
        public abstract SquareMatrix<T> Visit(SquareMatrix<T> matrix);

        /// <summary>
        /// Visits the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>Returns a square matrix</returns>
        public abstract SquareMatrix<T> Visit(SymentricMatrix<T> matrix);
    }
}

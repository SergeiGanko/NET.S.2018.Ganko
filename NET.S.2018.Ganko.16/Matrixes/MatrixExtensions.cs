using System;

namespace Matrixes
{
    /// <summary>
    /// Class MatrixExtensions
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Compute sum of two matrices.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix">The matrix.</param>
        /// <param name="other">The other matrix.</param>
        /// <param name="rule">The rule which determines operation of addition.</param>
        /// <returns>Returns a square matrix which obtained as a result of addition of two matrices</returns>
        /// <exception cref="ArgumentNullException">Throws when the other matrix is null</exception>
        public static Matrix<T> Sum<T>(this Matrix<T> matrix, Matrix<T> other, Func<T, T, T> rule)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"Argument {nameof(other)} is null");
            }

            var visitor = new ComputeSumVisitor<T>(other, rule);

            visitor.DynamicVisit(matrix);

            return visitor.Result;
        }
    }
}

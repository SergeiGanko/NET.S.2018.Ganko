using NUnit.Framework;

namespace Matrices.Tests
{
    using Matrixes;

    [TestFixture]
    public class MatrixExtensionsTests
    {
        [Test]
        public void SumExtensionMethod_ComputeSumOfTwoSquareMatrices()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 7, 2, 8 },
                    new[] { 3, 1, 6 }
                };

            var matrix = new SquareMatrix<int>(testArray);
            var other = new SquareMatrix<int>(testArray);

            var actualResult = matrix.Sum(other, (m, n) => m + n);

            int[][] expectedArray =
                {
                    new[] { 8, 2, 10 },
                    new[] { 14, 4, 16 },
                    new[] { 6, 2, 12 }
                };

            var expectedResult = new SquareMatrix<int>(expectedArray);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], actualResult[i, j]);
                }
            }
        }

        [Test]
        public void SumExtensionMethod_ComputeSumOfTwoDiagonalMatrices()
        {
            int[] testArray = { 4, 6, 2 };

            var matrix = new DiagonalMatrix<int>(testArray);
            var other = new DiagonalMatrix<int>(testArray);

            var actualResult = matrix.Sum(other, (m, n) => m + n);

            int[][] expectedArray =
                {
                    new[] { 8, 0, 0 },
                    new[] { 0, 12, 0 },
                    new[] { 0, 0, 4 }
                };

            var expectedResult = new SquareMatrix<int>(expectedArray);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], actualResult[i, j]);
                }
            }
        }

        [Test]
        public void SumExtensionMethod_ComputeSumOfTwoSymetricMatrices()
        {
            int[][] testArray =
                {
                    new[] { 1, 3, 0 },
                    new[] { 3, 2, 6 },
                    new[] { 0, 6, 5 }
                };

            var matrix = new SymentricMatrix<int>(testArray);
            var other = new SymentricMatrix<int>(testArray);

            var actualResult = matrix.Sum(other, (m, n) => m + n);

            int[][] expectedArray =
                {
                    new[] { 2, 6, 0 },
                    new[] { 6, 4, 12 },
                    new[] { 0, 12, 10 }
                };

            var expectedResult = new SquareMatrix<int>(expectedArray);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], actualResult[i, j]);
                }
            }
        }

        [Test]
        public void SumExtensionMethod_ComputeSumOfSquareMatrixAndSymetricMatrix()
        {
            int[][] squareArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 7, 2, 8 },
                    new[] { 3, 1, 6 }
                };

            int[][] symetricArray =
                {
                    new[] { 1, 3, 0 },
                    new[] { 3, 2, 6 },
                    new[] { 0, 6, 5 }
                };

            var matrix = new SquareMatrix<int>(squareArray);
            var other = new SymentricMatrix<int>(symetricArray);

            var actualResult = matrix.Sum(other, (m, n) => m + n);

            int[][] expectedArray =
                {
                    new[] { 5, 4, 5 },
                    new[] { 10, 4, 14 },
                    new[] { 3, 7, 11 }
                };

            var expectedResult = new SquareMatrix<int>(expectedArray);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], actualResult[i, j]);
                }
            }
        }
    }
}

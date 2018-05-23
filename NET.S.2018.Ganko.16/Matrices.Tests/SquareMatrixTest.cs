using System;
using System.Linq;
using NUnit.Framework;
using Matrixes;

namespace Matrices.Tests
{
    [TestFixture]
    public class SquareMatrixTest
    {
        [Test]
        public void SquareMatrixCtor_InputOrderAsParameter()
        {
            var order = 3;

            var matrix = new SquareMatrix<int>(order);

            Assert.AreEqual(order, matrix.Order);
        }

        [Test]
        public void SquareMatrixCtor_InputJaggedArrayAsParameter()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 7, 2, 8 },
                    new[] { 3, 1, 6 }
                };

            var matrix = new SquareMatrix<int>(testArray);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(testArray[i].ElementAt(j), matrix[i, j]);
                }
            }
        }

        [Test]
        public void SquareMatrixCtor_InputArrayAsParameter()
        {
            int[] testArray = { 1, 3, 0, 3, 2, 6, 0, 6, 5 };

            var matrix = new SquareMatrix<int>(testArray);

            int[,] expectedResult = { { 1, 3, 0 }, { 3, 2, 6 }, { 0, 6, 5 } };

            CollectionAssert.AreEqual(expectedResult, matrix);
        }

        [Test]
        public void SquareMatrixCtor_InputNullAsParameter_ExpectArgumentNullException()
        {
            int[][] testArray = null;
            Assert.Throws<ArgumentNullException>(() => new SquareMatrix<int>(testArray));
        }

        [Test]
        public void SquareMatrixCtor_InputMinusTwoAsParameter_ExpectArgumentException()
            => Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(-2));

        [Test]
        public void SquareMatrixCtor_InputNonSquareJaggedArray_ExpectArgumentException()
        {
            int[][] testArray =
                {
                    new[] { 4, 1 },
                    new[] { 7, 2, 8 },
                    new[] { 3, 1, 6 }
                };

            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(testArray));
        }
    }
}

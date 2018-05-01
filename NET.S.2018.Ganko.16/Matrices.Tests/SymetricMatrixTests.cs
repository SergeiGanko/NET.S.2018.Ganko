using System;
using System.Linq;
using NUnit.Framework;
using Matrixes;

namespace Matrices.Tests
{
    [TestFixture]
    public class SymetricMatrixTests
    {
        [Test]
        public void SymentricMatrixCtor_InputOrderAsParameter()
        {
            var order = 3;

            var matrix = new SymentricMatrix<int>(order);

            Assert.AreEqual(order, matrix.Order);
        }

        [Test]
        public void SymentricMatrixCtor_InputJaggedArrayAsParameter()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 1, 2, 8 },
                    new[] { 5, 8, 6 }
                };

            var matrix = new SymentricMatrix<int>(testArray);

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(testArray[i].ElementAt(j), matrix[i, j]);
                }
            }
        }

        [Test]
        public void SymentricMatrixCtor_InputArrayAsParameter()
        {
            int[] testArray = { 1, 3, 0, 3, 2, 6, 0, 6, 5 };

            var matrix = new SymentricMatrix<int>(testArray);

            int[,] expectedResult = { { 1, 3, 0 }, { 3, 2, 6 }, { 0, 6, 5 } };

            CollectionAssert.AreEqual(expectedResult, matrix);
        }

        [Test]
        public void SymentricMatrixCtor_InputNonSquareJaggedArrayAsParameter_ExpectArgumentException()
        {
            int[][] testArray =
                {
                    new[] { 4, 1 },
                    new[] { 1, 2, 8 },
                    new[] { 5, 8, 6 }
                };

            Assert.Throws<ArgumentException>(() => new SymentricMatrix<int>(testArray));
        }

        [Test]
        public void SymentricMatrixCtor_InputNullAsParameter_ExpectArgumentNullException()
        {
            int[][] testArray = null;

            Assert.Throws<ArgumentNullException>(() => new SymentricMatrix<int>(testArray));
        }

        [Test]
        public void SymentricMatrixCtor_InputMinusTwoAsParameter_ExpectArgumentException()
            => Assert.Throws<ArgumentException>(() => new SymentricMatrix<int>(-2));

        [Test]
        public void SymentricMatrixCtor_InputNonSymetricJaggedArray_ExpectArgumentException()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 2 },
                    new[] { 7, 2, 8 },
                    new[] { 3, 1, 6 }
                };

            Assert.Throws<ArgumentException>(() => new SymentricMatrix<int>(testArray));
        }
    }
}

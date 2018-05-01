using System;
using NUnit.Framework;
using Matrixes;

namespace Matrices.Tests
{
    [TestFixture]
    public class DiagonalMatrixTests
    {
        [Test]
        public void DiagonalMatrixCtor_InputOrderAsParameter()
        {
            var order = 3;

            var matrix = new DiagonalMatrix<int>(order);

            Assert.AreEqual(order, matrix.Order);
        }

        [Test]
        public void DiagonalMatrixCtor_InputArrayAsParameter()
        {
            int[] testArray = { 11, 11, 11 };

            var matrix = new DiagonalMatrix<int>(testArray);

            int[,] expectedResult = { { 11, 0, 0 }, { 0, 11, 0 }, { 0, 0, 11 } };

            CollectionAssert.AreEqual(expectedResult, matrix);
        }

        [Test]
        public void DiagonalMatrixCtor_InputMinusTwoAsParameter_ExpectArgumentException()
            => Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(-2));

        [Test]
        public void DiagonalMatrixCtor_InputNonSquareJaggedArray_ExpectArgumentException()
        {
            int[] testArray = null;
            Assert.Throws<ArgumentNullException>(() => new DiagonalMatrix<int>(testArray));
        }
    }
}

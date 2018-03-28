using System;
using NUnit.Framework;

namespace WorkingWithPolynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void Polynomial_PassNull_ExpectArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        [TestCase(new double[0])]
        public void Polynomial_PassEmptyArray_ExpectArgumentException(params double[] input)
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(input));
        }

        [TestCase(new double[] { 3.5, 5, 1, 0.000000001 }, ExpectedResult = 2)]
        public int DegreeProperty_PassArraWith4elemets_ExpectDegree2(params double[] input) => new Polynomial(input).Degree;

        [Test]
        public void Indexer_Pass2_Expect73()
        {
            var poly1 = new Polynomial(1.5, 6, 73, 1.7);
            double expectedResult = 73.0;

            double actualResult = poly1[2];

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void Indexer_PassInvalidArgument_ExpectArgumentOutOfRangeException(int i)
        {
            var poly1 = new Polynomial(1.5, 6, 3.75);
            double result;
            Assert.Throws<ArgumentOutOfRangeException>(() => result = poly1[i]);
        }

        [Test]
        public void EqualsObject_ExpectTrue()
        {
            var poly1 = new Polynomial(1.5, 6, 3.75);
            object obj = poly1;

            Assert.True(poly1.Equals(obj));
        }

        [Test]
        public void EqualsOnePolynomialTwoRefs_ExpectTrue()
        {
            var poly1 = new Polynomial(1.5, 6, 3.75);
            var poly2 = poly1;

            Assert.True(poly1.Equals(poly2));
        }

        [Test]
        public void EqualstwoPolynomial_ExpectTrue()
        {
            var poly1 = new Polynomial(1.5, 6, 3.75, 0.00000001, 0.000000065);
            var poly2 = new Polynomial(1.5, 6, 3.75);

            Assert.True((poly1.Degree).Equals(poly2.Degree));
            Assert.True((poly1).Equals(poly2));
        }

        [Test]
        public void EqualsPolynomial_ExpectFalse()
        {
            var poly1 = new Polynomial(1.5, 6, 3.75, 53.1);
            var poly2 = new Polynomial(1.5, 6, 3.75);

            Assert.False(poly2.Equals(poly1));
        }

        [TestCase(new double[] { 0.3, 2, 1.5 }, new double[] { 1.3, 3, 2.5, 8 }, new double[] { 1.6, 5, 4, 8 })]
        [TestCase(new double[] { 1.3, 3, 2.5, 8 }, new double[] { 0.3, 2, 1.5 }, new double[] { 1.6, 5, 4, 8 })]
        public void OperatorPlus_Pass2Polynomials_ExpectPolynomial(double[] array1, double[] array2, double[] expectArray)
        {
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(expectArray);

            Polynomial actual = polynomial1 + polynomial2;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 0.3, 2, 1.5 }, new double[] { 1.3, 3, 2.5, 8 }, new double[] { -1, -1, -1, -8 })]
        [TestCase(new double[] { 1.3, 3, 2.5, 8 }, new double[] { 0.3, 2, 1.5 }, new double[] { 1, 1, 1, 8 })]
        public void OperatorMinus_Pass2Polynomials_ExpectPolynomial(double[] array1, double[] array2, double[] expectArray)
        {
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(expectArray);

            Polynomial actual = polynomial1 - polynomial2;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 0.3, 2, 1.5 }, new double[] { 1.3, 3, 2.5, 8 }, new double[] { 0.39, 6, 3.75, 0 })]
        [TestCase(new double[] { 1.3, 3, 2.5, 8 }, new double[] { 0.3, 2, 1.5 }, new double[] { 0.39, 6, 3.75, 0 })]
        [TestCase(new double[] { 1.3, 3, 2.5, 8, 0.000001 }, new double[] { 0.3, 2, 1.5, 0.000001 }, new double[] { 0.39, 6, 3.75, 0, 0 })]
        public void OperatorMultiply_Pass2Polynomials_ExpectPolynomial(double[] array1, double[] array2, double[] expectArray)
        {
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(expectArray);

            Polynomial actual = polynomial1 * polynomial2;

            Assert.AreEqual(expected, actual);
        }


    }
}

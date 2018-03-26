using System;
using NUnit.Framework;

namespace WorkingWithPolynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        private readonly Polynomial polynomial = 
            new Polynomial(new double[] { 77, 23, 73, 11.5 });

        [Test]
        public void Polynomial_PassNull_ExpectArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        [Test]
        public void Polynomial_PassEmptyArray_ExpectArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(new double[0]));
        }

        [Test]
        public void Indexer_Pass2_Expect73()
        {
            double expectedResult = 73.0;

            double actualResult = polynomial[2];

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-1)]
        [TestCase(10)]
        public void Indexer_PassInvalidArgument_ExpectArgumentOutOfRangeException(int i)
        {
            double result;
            Assert.Throws<ArgumentOutOfRangeException>(() => result = this.polynomial[i]);
        }

        [Test]
        public void EqualsObject_ExpectTrue()
        {
            object obj = this.polynomial;

            Assert.True(this.polynomial.Equals(obj));
        }

        [Test]
        public void EqualsPolynomial_ExpectTrue()
        {
            var polynomial2 = this.polynomial;

            Assert.True(this.polynomial.Equals(polynomial2));
        }

        [Test]
        public void EqualsPolynomial_ExpectFalse()
        {
            var polynomial2 = new Polynomial(new double[] { 1, 0, 2 });

            Assert.False(this.polynomial.Equals(polynomial2));
        }

        [TestCase(new double[] { 0.3, 2, 1.5 }, new double[] { 1.3, 3, 2.5, 8 }, ExpectedResult = new double[] { 1.6, 5, 4, 8 })]
        [TestCase(new double[] { 1.3, 3, 2.5, 8 }, new double[] { 0.3, 2, 1.5 }, ExpectedResult = new double[] { 1.6, 5, 4, 8 })]
        public double[] OperatorPlus_Pass2Polynomials_ExpectPolynomial(double[] array1, double[] array2)
        {
            Polynomial polynomial2 = new Polynomial(array1);
            Polynomial polynomial1 = new Polynomial(array2);

            Polynomial result = polynomial1 + polynomial2;

            return result.Coeffs;
        }

        [TestCase(new double[] { 0.3, 2, 1.5 }, new double[] { 1.3, 3, 2.5, 8 }, ExpectedResult = new double[] { -1, -1, -1, -8 })]
        [TestCase(new double[] { 1.3, 3, 2.5, 8 }, new double[] { 0.3, 2, 1.5 }, ExpectedResult = new double[] { 1, 1, 1, 8 })]
        public double[] OperatorMinus_Pass2Polynomials_ExpectPolynomial(double[] array1, double[] array2)
        {
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            Polynomial result = polynomial1 - polynomial2;

            return result.Coeffs;
        }

        [Test]
        public void OperatorMultiply_Pass2Polynomials_ExpectPolynomial()
        {
            Polynomial polynomial1 = new Polynomial(new double[] { 0.3, 2, 1.5 });
            Polynomial polynomial2 = new Polynomial(new double[] { 1.3, 3, 2.5, 8 });

            Polynomial expectedResult = new Polynomial(new double[] { 0.39, 6, 3.75, 0 });

            Polynomial result = polynomial1 * polynomial2;

            CollectionAssert.AreEqual(expectedResult.Coeffs, result.Coeffs);
        }
    }
}

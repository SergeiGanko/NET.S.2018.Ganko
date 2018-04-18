using System;
using System.Collections.Generic;
using static Fibonacci.FibonacciGenerator;
using NUnit.Framework;
using System.Collections;
using System.Numerics;

namespace Fibonacci.Tests
{
    [TestFixture]
    public class FibonacciGeneratorTests
    {
        public static IEnumerable FibonacciSequanceTestCases
        {
            get
            {
                yield return new TestCaseData(1).Returns(new BigInteger[] { 1 });
                yield return new TestCaseData(7).Returns(new BigInteger[] { 1, 1, 2, 3, 5, 8, 13 });
                yield return new TestCaseData(5).Returns(new BigInteger[] { 1, 1, 2, 3, 5 });
                yield return new TestCaseData(15).Returns(new BigInteger[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 });
                yield return new TestCaseData(22).Returns(new BigInteger[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711 });
            }
        }

        [TestCaseSource(nameof(FibonacciSequanceTestCases))]
        public IEnumerable<BigInteger> Generate_Passes9_ExpectsArray(int length)
        {
            return GenerateFibonacci(length);
        }

        [TestCase(-1)]
        public void Generate_PassesMinus1_ExpectsArgumentException(int length)
        {
            Assert.Throws<ArgumentException>(() => GenerateFibonacci(length));
        }
    }
}
using System.Collections.Generic;
using static Fibonacci.FibonacciGenerator;
using NUnit.Framework;
using System.Collections;

namespace Fibonacci.Tests
{
    [TestFixture]
    public class FibonacciGeneratorTests
    {
        public static IEnumerable FibonacciSequanceTestCases
        {
            get
            {
                yield return new TestCaseData(1).Returns(new long[] { 1 });
                yield return new TestCaseData(7).Returns(new long[] { 1, 1, 2, 3, 5, 8, 13 });
                yield return new TestCaseData(5).Returns(new long[] { 1, 1, 2, 3, 5 });
                yield return new TestCaseData(15).Returns(new long[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 });
                yield return new TestCaseData(22).Returns(new long[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711 });
            }
        }

        [TestCaseSource(nameof(FibonacciSequanceTestCases))]
        public IEnumerable<long> Generate_Passes9_ExpectsArray(int length)
        {
            return Generate(length);
        }
    }
}
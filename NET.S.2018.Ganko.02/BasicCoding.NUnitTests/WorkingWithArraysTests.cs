using System;
using System.Collections;
using NUnit.Framework;

namespace BasicCoding.NUnitTests
{
    [TestFixture]
    public class WorkingWithArraysTests
    {
        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.TestCases))]
        public int[] FilterDigit_PassesArrayAndDigit_ExpectsArrayWithElementWhichContainDigit(int[] input, int digit) =>
            WorkingWithArrays.FilterDigit(input, digit);

        [Test]
        public void FilterDigit_PassesNullAsArgument_ExpectsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => WorkingWithArrays.FilterDigit(null, 3));

        [Test]
        public void FilterDigit_PassesEmptyArray_ExpectsArgumentException() =>
            Assert.Throws<ArgumentException>(() => WorkingWithArrays.FilterDigit(new int[0], 3));

        [Test]
        public void FilterDigit_PassesArrayAndInvalidDigit_ExpectsArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => WorkingWithArrays.FilterDigit(new int[] { 3, 23, 8 }, 12));
    }

    public class DataForTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { -1, -53, -12412312, -555, -2137 }, 3)
                    .Returns(new int[] { -53, -12412312, -2137 });
                yield return new TestCaseData(new int[] { int.MaxValue, -1, 0, 535, -2, -7341451, int.MinValue }, 3)
                    .Returns(new int[] { int.MaxValue, 535, -7341451, int.MinValue });
                yield return new TestCaseData(new int[] { 0, 1, 0, 1, 0, 0 }, 0)
                    .Returns(new int[] { 0, 0, 0, 0 });
            }
        }
    }
}

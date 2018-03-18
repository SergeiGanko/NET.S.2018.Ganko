using System;
using NUnit.Framework;
using static BasicCoding.WorkingWithNumbers;

namespace BasicCoding.NUnitTests
{
    [TestFixture]
    public class WorkingWithNumbersTests
    {
        #region FilterDigitTests

        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.FilerDigitTestCases))]
        public int[] FilterDigit_PassesArrayAndDigit_ExpectsArrayWithElementsWhichContainDigit(int[] input, int digit) =>
            FilterDigit(input, digit);

        [Test]
        public void FilterDigit_PassesNullAsArgument_ExpectsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => FilterDigit(null, 3));

        [Test]
        public void FilterDigit_PassesEmptyArray_ExpectsArgumentException() =>
            Assert.Throws<ArgumentException>(() => FilterDigit(new int[0], 3));

        [Test]
        public void FilterDigit_PassesArrayAndInvalidDigit_ExpectsArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => FilterDigit(new int[] { 3, 23, 8 }, 12));

        #endregion

        #region FindNextBiggerNumberTests

        [TestCase(1234, ExpectedResult = 1243)]
        [TestCase(2018, ExpectedResult = 2081)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber_PassesValidNumber_ExpectsNextBiggerNumberOrFalse(int number) => 
            FindNextBiggerNumber(number);

        [TestCase(int.MinValue)]
        [TestCase(0)]
        public void FindNextBiggerNumber_PassesInvalidNumber_ExpectsArgumentOutOfRangeException(int number) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => FindNextBiggerNumber(number));

        [TestCase(4132, 4213)]
        [TestCase(111, -1)]
        public void FindNextBiggerNumberAndTimeOfWorking_PassesValidNumber_ExpectsTupleOfNextBiggerNumberAndWokingTime(
            int inputNumber, int expectedNumber)
        {
            double expectMilliseconds = 10;

            var tuple = FindNextBiggerNumberAndTimeOfWorking(inputNumber);

            Assert.AreEqual(expectedNumber, tuple.Item1);
            Assert.GreaterOrEqual(expectMilliseconds, tuple.Item2);
        }

        [TestCase(414, 441)]
        [TestCase(222, -1)]
        public void FindNextBiggerNumberAndTimeOfWorking_PassesValidNumberAndOutParameterOfMilliseconds_ExpectsNextBiggerNumberAndWokingTime(
            int inputNumber, int expectedNumber)
        {
            double expectMilliseconds = 10;

            var actualNumber = FindNextBiggerNumberAndTimeOfWorking(inputNumber, out var actualMilliseconds);

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.GreaterOrEqual(expectMilliseconds, actualMilliseconds);
        }

        #endregion
    }
}

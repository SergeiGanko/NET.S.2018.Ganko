using System;
using System.Diagnostics;
using NUnit.Framework;
using static BasicCoding.WorkingWithNumbers;
using System.Collections.Generic;

namespace BasicCoding.NUnitTests
{
    [TestFixture]
    public class WorkingWithNumbersTests
    {
        #region FilterDigitTests

        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.FilerDigitTestCases))]
        public IEnumerable<int> FilterDigit_PassesArrayAndDigit_ExpectsArrayWithElementsWhichContainDigit(int[] input, IPredicate<int> predicate)
        {
            return input.Filter(predicate);
        }

        [Test]
        public void FilterDigit_PassesArrayAndInvalidDigit_ExpectsArgumentOutOfRangeException()
        {
            int[] testArray = { 3, 23, 8 };
            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.Filter(new ContainDigit(12)));
        }

        [Test]
        public void FilterDigit_FilterNegativeNembers()
        {
            int[] testArray = { 65, 123542, -3421, 0, 234, -6, -75 };
            IPredicate<int> predicate = new NegativeNumber();
            int[] expectedArray = { -3421, -6, -75 };

            var actualArray = testArray.Filter(predicate);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void FilterDigit_FilterEvenNumbers()
        {
            int[] testArray = { 65, 123542, -3421, 0, 234, -6, -75 };
            IPredicate<int> predicate = new EvenNumber();
            int[] expectedArray = { 123542, 0, 234, -6 };

            var actualArray = testArray.Filter(predicate);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

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
            var tuple = FindNextBiggerNumberAndTimeOfWorking(inputNumber);

            Assert.AreEqual(expectedNumber, tuple.Item1);
            Debug.WriteLine($"Method's working time: {tuple.Item2}");
        }

        [TestCase(414, 441)]
        [TestCase(222, -1)]
        public void FindNextBiggerNumberAndTimeOfWorking_PassesValidNumberAndOutParameterOfMilliseconds_ExpectsNextBiggerNumberAndWokingTime(
            int inputNumber, int expectedNumber)
        {
            var actualNumber = FindNextBiggerNumberAndTimeOfWorking(inputNumber, out var actualMilliseconds);

            Assert.AreEqual(expectedNumber, actualNumber);
            Debug.WriteLine($"Method's working time: {actualMilliseconds}");
        }

        #endregion

        #region FindNthRootTests

        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_Number_Degree_Presicion_ExpectsRoot(double number, int degree, double precision, double expected)
        {
            double actualResult = FindNthRoot(number, degree, precision);
            Assert.AreEqual(expected, actualResult, precision);
        }

        [TestCase(8, 15, -7)]
        [TestCase(9, 0, 0.01)]
        [TestCase(-4, 2, 0.01)]
        public void FindNthRoot_Number_Degree_Presicion_ArgumentOutOfRangeException(double number, int degree, double precision) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => FindNthRoot(number, degree, precision));

        #endregion

        #region InsertNumberTests

        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(-5, -2, 0, 0, ExpectedResult = -6)]
        [TestCase(-5, -2, 2, 4, ExpectedResult = -5)]
        public int InsertNumber_NumberSource_NumberIn_FromBit_ToBit_ExpectsNumber(
            int numberSource, 
            int numberIn, 
            int fromBit, 
            int toBit) 
            => InsertNumber(numberSource, numberIn, fromBit, toBit);

        [TestCase(8, 15, 5, 2)]
        [TestCase(8, 15, -5, 2)]
        [TestCase(8, 15, 5, -2)]
        [TestCase(8, 15, 32, 2)]
        [TestCase(8, 15, 5, 32)]
        public void InsertNumber_NumberSource_NumberIn_FromBit_ToBit_ExpectsArgOutOfRangeException(
            int numberSource,
            int numberIn,
            int fromBit,
            int toBit) =>
            Assert.Throws<ArgumentOutOfRangeException>((() => InsertNumber(numberSource, numberIn, fromBit, toBit)));

        #endregion
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static BasicCoding.WorkingWithNumbers;
using BasicCoding.NUnitTests;
using System.Linq;

namespace BasicCoding.Tests
{
    [TestClass]
    public class WorkingWithNumbersTests
    {
        #region Private Fields

        /// <summary>
        /// The get random
        /// </summary>
        private static readonly Random getRandom = new Random();

        /// <summary>
        /// The input array
        /// </summary>
        private static int[] inputArray;

        /// <summary>
        /// The expect result array
        /// </summary>
        private static int[] expectResultArray;

        #endregion

        #region Filter Digit Tests

        [TestMethod]
        public void FilterDigit_PassesArrayOfIntsAndDigit_ExpectsArrayWithElementsWhichContainDigit()
        {
            // Arrange
            int digit = 3;
            int n = 1000000;
            InitializeActualResultArrayAndExpectResultArray(n, digit, int.MinValue, int.MaxValue);

            // Act
            var actualResultArray = inputArray.Filter(new ContainDigit(3));

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray.ToArray());
        }

        [TestMethod]
        public void FilterDigit_PassesArrayOfPositiveIntsAndDigit_ExpectsArrayWithElementsWhichContainDigit()
        {
            // Arrange
            int digit = 3;
            int n = 1000000;
            InitializeActualResultArrayAndExpectResultArray(n, digit, 0, int.MaxValue);

            // Act
            var actualResultArray = inputArray.Filter(new ContainDigit(3));

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray.ToArray());
        }

        [TestMethod]
        public void FilterDigit_PassesArrayOfNegativeIntsAndDigit_ExpectsArrayWithElementsWhichContainDigit()
        {
            // Arrange
            int digit = 3;
            int n = 1000000;
            InitializeActualResultArrayAndExpectResultArray(n, digit, int.MinValue, 0);

            // Act
            var actualResultArray = inputArray.Filter(new ContainDigit(3));

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_PassesArrayAndInvalidDigit_ExpectsArgumentOutOfRangeException()
        {
            inputArray = new[] { 51, 34, 173, 2, 69, 16, 3, 4 };
            inputArray.Filter(new ContainDigit(12));
        }

        #endregion

        #region FindNextBiggerNumber Tests

        [TestMethod]
        public void FindNextBiggerNumber_Passes1234_Expects1243()
        {
            int inputNumber = 1234;
            int expectNumber = 1243;

            int actualNumber = FindNextBiggerNumber(inputNumber);

            Assert.AreEqual(expectNumber, actualNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNextBiggerNumber_PassesIntMinValue_ExpectsArgumentOutOfRangeException() =>
            FindNextBiggerNumber(int.MinValue);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNextBiggerNumber_PassesZero_ExpectsArgumentOutOfRangeException() =>
            FindNextBiggerNumber(0);

        [TestMethod]
        public void FindNextBiggerNumber_Passes10_ExpectsMinus1() =>
            FindNextBiggerNumber(10);

        [TestMethod]
        public void FindNextBiggerNumber_PassesIntMaxValue_ExpectsMinus1() =>
            FindNextBiggerNumber(int.MaxValue);

        [TestMethod]
        public void FindNextBiggerNumberAndTimeOfWorking_Passes1234_Expects1243AndWorkingTime()
        {
            int inputNumber = 1234;
            int expectNumber = 1243;
            double expectMilliseconds = 1000000;

            var tuple = FindNextBiggerNumberAndTimeOfWorking(inputNumber);

            Assert.AreEqual(expectNumber, tuple.Item1);
        }

        #endregion

        #region FindNthRoot Tests

        [TestMethod]
        public void FindNthRoot_8_3_00001_Expects2()
        {
            double number = 8;
            int degree = 3;
            double precision = 0.0001;
            double expectResult = 2;

            double actualResult = FindNthRoot(number, degree, precision);

            Assert.AreEqual(expectResult, actualResult, precision);
        }

        [TestMethod]
        public void FindNthRoot_Minus0008_3_01_ExpectsMinus02()
        {
            double number = -0.008;
            int degree = 3;
            double precision = 0.1;
            double expectResult = -0.2;

            double actualResult = FindNthRoot(number, degree, precision);

            Assert.AreEqual(expectResult, actualResult, precision);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_8_15_Minus7_ExpectsArgumentOutOfRangeException() => FindNthRoot(8, 15, -7);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_9_0_001_ExpectsArgumentOutOfRangeException() => FindNthRoot(9, 0, 0.01);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_Minus4_2_001_ExpectsArgumentOutOfRangeException() => FindNthRoot(-4, 2, 0.01);

        #endregion

        #region InsertNumber Tests

        [TestMethod]
        public void InsertNumber_Passes8_15_0_0_Expects9()
        {
            int numberSource = 8;
            int numberIn = 15;
            int fromBit = 0;
            int toBit = 0;
            int expectedResult = 9;

            int actualResult = InsertNumber(numberSource, numberIn, fromBit, toBit);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertNumber_Passes8_15_3_8_Expects120()
        {
            int numberSource = 8;
            int numberIn = 15;
            int fromBit = 3;
            int toBit = 8;
            int expectedResult = 120;

            int actualResult = InsertNumber(numberSource, numberIn, fromBit, toBit);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_Passes8_15_8_3_ExpectsAngumentOutOfRangeException() => InsertNumber(8, 15, 8, 3);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_Passes8_15_Minus8_3_ExpectsAngumentOutOfRangeException() => InsertNumber(8, 15, -8, 3);

        #endregion

        #region Private Methods

        private static void InitializeActualResultArrayAndExpectResultArray(int n, int digit, int min, int max)
        {
            List<int> randomList = new List<int>();
            List<int> filteredList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                randomList.Add(GetRandom(min, max));
            }

            inputArray = randomList.ToArray();

            foreach (var item in randomList)
            {
                if (item.ToString().Contains(digit.ToString()))
                {
                    filteredList.Add(item);
                }
            }

            expectResultArray = filteredList.ToArray();
        }

        private static int GetRandom(int min, int max)
        {
            return getRandom.Next(min, max);
        }

        #endregion
    }
}

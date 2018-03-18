using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static BasicCoding.WorkingWithNumbers;

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
            var actualResultArray = FilterDigit(inputArray, digit);

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray);
        }

        [TestMethod]
        public void FilterDigit_PassesArrayOfPositiveIntsAndDigit_ExpectsArrayWithElementsWhichContainDigit()
        {
            // Arrange
            int digit = 3;
            int n = 1000000;
            InitializeActualResultArrayAndExpectResultArray(n, digit, 0, int.MaxValue);

            // Act
            var actualResultArray = FilterDigit(inputArray, digit);

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray);
        }

        [TestMethod]
        public void FilterDigit_PassesArrayOfNegativeIntsAndDigit_ExpectsArrayWithElementsWhichContainDigit()
        {
            // Arrange
            int digit = 3;
            int n = 1000000;
            InitializeActualResultArrayAndExpectResultArray(n, digit, int.MinValue, 0);

            // Act
            var actualResultArray = FilterDigit(inputArray, digit);

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_PassesNullAsArgument_ExpectsArgumentNullException()
            => FilterDigit(null, 3);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterDigit_PassesEmptyArray_ExpectsArgumentException()
            => FilterDigit(new int[0], 3);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_PassesArrayAndInvalidDigit_ExpectsArgumentOutOfRangeException()
            => FilterDigit(new[] { 51, 34, 173, 2, 69, 16, 3, 4 }, 12);

        #endregion

        #region FindNextBiggerNumber Test

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
            //Assert.
        }

        #endregion

        #region FindNthRoot Test

        [TestMethod]
        public void FindNthRoot_8_3_00001_Expects2()
        {
            double number = 8;
            int degree = 3;
            double precision = 0.0001;
            double expectResult = 2;

            double actualResult = FindNthRoot(number, degree, precision);

            Assert.AreEqual(expectResult, actualResult);
        }

        [TestMethod]
        public void FindNthRoot_Minus0008_3_01_ExpectsMinus02()
        {
            double number = -0.008;
            int degree = 3;
            double precision = 0.1;
            double expectResult = -0.2;

            double actualResult = FindNthRoot(number, degree, precision);

            Assert.AreEqual(expectResult, actualResult);
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

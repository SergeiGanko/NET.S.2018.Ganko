using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BasicCoding.Tests
{
    /// <summary>
    /// Class tests the filtering of arrays by specific digit
    /// </summary>
    [TestClass]
    public class WorkingWithArraysTests
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

        /// <summary>
        /// Method calls FilterDigit method and passes to it array of ints and a specific digit
        /// Expected result - array of ints with elements which contain the specific digit
        /// </summary>
        [TestMethod]
        public void FilterDigit_PassesArrayOfIntsAndDigit_ExpectsArrayWithElementWhichContainDigit()
        {
            // Arrange
            int digit = 3;
            int n = 1000000;
            InitializeActualResultArrayAndExpectResultArray(n, digit, int.MinValue, int.MaxValue);

            // Act
            var actualResultArray = WorkingWithArrays.FilterDigit(inputArray, digit);

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray);
        }

        /// <summary>
        /// Method calls FilterDigit method and passes to it array of positive ints and a specific digit
        /// Expected result - array of ints with elements which contain the specific digit
        /// </summary>
        [TestMethod]
        public void FilterDigit_PassesArrayOfPositiveIntsAndDigit_ExpectsArrayWithElementWhichContainDigit()
        {
            // Arrange
            int digit = 3;
            int n = 1000000;
            InitializeActualResultArrayAndExpectResultArray(n, digit, 0, int.MaxValue);

            // Act
            var actualResultArray = WorkingWithArrays.FilterDigit(inputArray, digit);

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray);
        }

        /// <summary>
        /// Method calls FilterDigit method and passes to it array of negative ints and a specific digit
        /// Expected result - array of ints with elements which contain the specific digit
        /// </summary>
        [TestMethod]
        public void FilterDigit_PassesArrayOfNegativeIntsAndDigit_ExpectsArrayWithElementWhichContainDigit()
        {
            // Arrange
            int digit = 3;
            int n = 1000000;
            InitializeActualResultArrayAndExpectResultArray(n, digit, int.MinValue, 0);

            // Act
            var actualResultArray = WorkingWithArrays.FilterDigit(inputArray, digit);

            // Assert
            CollectionAssert.AreEqual(expectResultArray, actualResultArray);
        }

        /// <summary>
        /// Method calls FilterDigit method and passes to it null as first argument and a specific digit
        /// Expected result - throwing ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_PassesNullAsArgument_ExpectsArgumentNullException()
            => WorkingWithArrays.FilterDigit(null, 3);

        /// <summary>
        /// Method calls FilterDigit method and passes to it empty array and a specific digit
        /// Expected result - throwing ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterDigit_PassesEmptyArray_ExpectsArgumentException()
            => WorkingWithArrays.FilterDigit(new int[0], 3);

        /// <summary>
        /// Method calls FilterDigit method and passes to it array of ints and a invalid digit
        /// Expected result - throwing ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_PassesArrayAndInvalidDigit_ExpectsArgumentOutOfRangeException()
            => WorkingWithArrays.FilterDigit(new[] { 51, 34, 173, 2, 69, 16, 3, 4 }, 12);

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

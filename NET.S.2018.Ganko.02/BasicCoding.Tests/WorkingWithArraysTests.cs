using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicCoding.Tests
{
    /// <summary>
    /// Class tests the filtering of arrays by specific digit
    /// </summary>
    [TestClass]
    public class WorkingWithArraysTests
    {
        /// <summary>
        /// Method calls FilterDigit method and passes to it array of ints and a specific digit
        /// Expected result - array of ints with elements which contain specific digit
        /// </summary>
        [TestMethod]
        public void FilterDigit_PassesArrayOfIntsAndDigit_ExpectsArrayWithElementWhichContainDigit()
        {
            // Arrange
            int[] input = { 51, 34, 173, 2, 69, 16, 3, 4 };
            int digit = 3;
            int[] expected = { 34, 173, 3 };

            // Act
            var actual = WorkingWithArrays.FilterDigit(input, digit);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
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
        [ExpectedException(typeof(ArgumentException))]
        public void FilterDigit_PassesArrayAndInvalidDigit_ExpectsArgumentException()
            => WorkingWithArrays.FilterDigit(new []{ 51, 34, 173, 2, 69, 16, 3, 4 }, 12);
    }
}

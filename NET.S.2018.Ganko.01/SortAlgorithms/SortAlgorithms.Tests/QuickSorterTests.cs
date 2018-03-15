using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortAlgorithms.Tests
{
    /// <summary>
    /// Class tests the sorting of arrays using quick sort algorithm
    /// </summary>
    [TestClass]
    public class QuickSorterTests
    {
        /// <summary>
        /// Method calls QuickSort method and passes to it unsorted array of ints
        /// Expected result - sorted array of ints
        /// </summary>
        [TestMethod]
        public void QuickSort_PassesUnsortedArray_ExpectsSortedArray()
        {
            // Arrange
            int[] unsorted = { 7, 3, -19, 2, 6, 1, 5, 4 };
            int[] sorted = { -19, 1, 2, 3, 4, 5, 6, 7 };

            // Act
            QuickSorter.QuickSort(unsorted);

            // Assert
            CollectionAssert.AreEqual(sorted, unsorted);
        }

        /// <summary>
        /// Method calls QuickSort method and passes to it null reference
        /// Expected result - throwing ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_PassesNullReference_ThrowArgumentNullExceptionn() => QuickSorter.QuickSort(null);

        /// <summary>
        /// Method calls QuickSort method and passes to it empty array
        /// Expected result - throwing ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_PassesEmptyArray_ThrowArgumentException() => QuickSorter.QuickSort(new int[0]);
    }
}

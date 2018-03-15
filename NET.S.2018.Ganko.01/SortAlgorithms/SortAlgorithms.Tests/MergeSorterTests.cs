using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortAlgorithms.Tests
{
    /// <summary>
    /// Class tests the sorting of arrays using merge sort algorithm
    /// </summary>
    [TestClass]
    public class MergeSorterTests
    {
        /// <summary>
        /// Method calls MergeSort method and passes to it unsorted array of ints
        /// Expected result - sorted array of ints
        /// </summary>
        [TestMethod]
        public void MergeSort_PassesUnsortedArray_ExpectsSortedArray()
        {
            // Arrange
            int[] unsorted = { 7, 3, -19, 2, 6, 1, 5 };
            int[] sorted = { -19, 1, 2, 3, 5, 6, 7 };

            // Act
            MergeSorter.MergeSort(unsorted);

            // Assert
            CollectionAssert.AreEqual(sorted, unsorted);
        }

        /// <summary>
        /// Method calls MergeSort method and passes to it null reference
        /// Expected result - throwing ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Merge_Sort_PassesNullReference_ThrowArgumentNullExceptionn() => MergeSorter.MergeSort(null);

        /// <summary>
        /// Method calls MergeSort method and passes to it empty array
        /// Expected result - throwing ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Merge_Sort_PassesEmptyArray_ThrowArgumentException() => MergeSorter.MergeSort(new int[0]);
    }
}

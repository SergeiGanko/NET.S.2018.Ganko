using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SortAlgorithms.Tests.TestArraysInitializer;

namespace SortAlgorithms.Tests
{
    [TestClass]
    public class ArraySorterTests
    {
        #region MergeSort tests

        [TestMethod]
        public void MergeSort_PassesUnsortedArrayOfPositiveValues_ExpectsSortedArray()
        {
            int n = 100;
            int minValue = 0;
            int maxValue = 100;
            InitializeActualResultArrayAndExpectResultArray(n, minValue, maxValue);

            ArraySorter.MergeSort(ActualResultArray);

            CollectionAssert.AreEqual(ExpectResultArray, ActualResultArray);
        }

        [TestMethod]
        public void MergeSort_PassesUnsortedArrayOfNegativeValues_ExpectsSortedArray()
        {
            int n = 100;
            int minValue = -100;
            int maxValue = 0;
            InitializeActualResultArrayAndExpectResultArray(n, minValue, maxValue);

            ArraySorter.MergeSort(ActualResultArray);

            CollectionAssert.AreEqual(ExpectResultArray, ActualResultArray);
        }

        [TestMethod]
        public void MergeSort_PassesEmptyArray_ExpectsEmptyArray()
        {
            int[] actualResultArray = new int[0];
            int[] expectResultArray = new int[0];

            ArraySorter.MergeSort(actualResultArray);

            CollectionAssert.AreEqual(expectResultArray, actualResultArray);
        }

        [TestMethod]
        public void MergeSort_PassesUnsortedArray_ExpectsSortedArray()
        {
            // Arrange
            int n = 10000000;
            InitializeActualResultArrayAndExpectResultArray(n, int.MinValue, int.MaxValue);
            
            // Act
            ArraySorter.MergeSort(ActualResultArray);

            // Assert
            CollectionAssert.AreEqual(ExpectResultArray, ActualResultArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_PassesNullReference_ThrowArgumentNullExceptionn() => ArraySorter.MergeSort(null);

        #endregion

        #region QuickSort tests

        [TestMethod]
        public void QuickSort_PassesUnsortedArrayOfPositiveValues_ExpectsSortedArray()
        {
            int n = 100;
            int minValue = 0;
            int maxValue = 100;
            InitializeActualResultArrayAndExpectResultArray(n, minValue, maxValue);

            ArraySorter.QuickSort(ActualResultArray);

            CollectionAssert.AreEqual(ExpectResultArray, ActualResultArray);
        }

        [TestMethod]
        public void QuickSort_PassesUnsortedArrayOfNegativeValues_ExpectsSortedArray()
        {
            int n = 100;
            int minValue = -100;
            int maxValue = 0;
            InitializeActualResultArrayAndExpectResultArray(n, minValue, maxValue);

            ArraySorter.QuickSort(ActualResultArray);

            CollectionAssert.AreEqual(ExpectResultArray, ActualResultArray);
        }

        [TestMethod]
        public void QuickSort_PassesEmptyArray_ExpectsEmptyArray()
        {
            int[] actualResultArray = new int[0];
            int[] expectResultArray = new int[0];

            ArraySorter.QuickSort(actualResultArray);

            CollectionAssert.AreEqual(expectResultArray, actualResultArray);
        }

        [TestMethod]
        public void QuickSort_PassesUnsortedArray_ExpectsSortedArray()
        {
            // Arrange
            int n = 10000000;
            InitializeActualResultArrayAndExpectResultArray(n, int.MinValue, int.MaxValue);

            // Act
            ArraySorter.QuickSort(ActualResultArray);

            // Assert
            CollectionAssert.AreEqual(ExpectResultArray, ActualResultArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_PassesNullReference_ThrowArgumentNullExceptionn() => ArraySorter.QuickSort(null);

        #endregion
    }
}

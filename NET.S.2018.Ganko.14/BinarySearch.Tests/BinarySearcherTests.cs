using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Collections;

namespace BinarySearch.Tests
{
    [TestFixture]
    public class BinarySearcherTests
    {
        #region Public Test Methods

        [TestCaseSource(nameof(IntArrarBinarySearchInterfaceTestData))]
        public int BinarySearch_Int_Comparer(int[] array, int item, IComparer<int> comparer)
        {
            return array.BinarySearch(item, comparer);
        }
        
        [TestCaseSource(nameof(IntArrayBinarySearchDelegateTestData))]
        public int BinarySearch_Int_Comparison(int[] array, int item, Comparison<int> comparison)
        {
            return array.BinarySearch(item, comparison);
        }

        [TestCaseSource(nameof(StringArrayBinarySearchInterfaceTestData))]
        public int BinarySearch_String_Comparer(string[] array, string item, IComparer<string> comparer)
        {
            return array.BinarySearch(item, comparer);
        }

        [TestCaseSource(nameof(StringArrayBinarySearchDelegateTestData))]
        public int BinarySearch_String_Comparison(string[] array, string item, Comparison<string> comparison)
        {
            return array.BinarySearch(item, comparison);
        }
        
        [TestCase(null, 3, null)]
        public void BinarySearch_ExpectsArgumentNullException(int[] array, int item, Comparison<int> comparison)
        {
            Assert.Throws<ArgumentNullException>(() => array.BinarySearch(item, comparison));
        }

        #endregion

        #region Test Case Data

        public static IEnumerable IntArrarBinarySearchInterfaceTestData
        {
            get
            {
                int[] testArray = { 1, 2, 3, 4, 5, 6, 7, 8 };
                var comparer = new IntComparer();

                yield return new TestCaseData(testArray, 7, comparer).Returns(6);
                yield return new TestCaseData(testArray, 0, comparer).Returns(-1);
                yield return new TestCaseData(testArray, 1, comparer).Returns(0);
                yield return new TestCaseData(testArray, 8, comparer).Returns(7);
            }
        }

        public static IEnumerable IntArrayBinarySearchDelegateTestData
        {
            get
            {
                int[] testArray = { 1, 2, 3, 4, 5, 6, 7, 8 };

                yield return new TestCaseData(testArray, 7, null).Returns(6);
                yield return new TestCaseData(testArray, 0, null).Returns(-1);
                yield return new TestCaseData(testArray, 1, null).Returns(0);
                yield return new TestCaseData(testArray, 8, null).Returns(7);

                Comparison<int> comparison = (e, f) => e.CompareTo(f);

                yield return new TestCaseData(testArray, 7, comparison).Returns(6);
                yield return new TestCaseData(testArray, 0, comparison).Returns(-1);
                yield return new TestCaseData(testArray, 1, comparison).Returns(0);
                yield return new TestCaseData(testArray, 8, comparison).Returns(7);
            }
        }

        public static IEnumerable StringArrayBinarySearchInterfaceTestData
        {
            get
            {
                string[] testArray = { "U", "v", "W", "X", "y", "Z" };
                var comparer = new StringComparer();

                yield return new TestCaseData(testArray, "x", comparer).Returns(3);
                yield return new TestCaseData(testArray, "U", comparer).Returns(0);
                yield return new TestCaseData(testArray, "F", comparer).Returns(-1);
                yield return new TestCaseData(testArray, "z", comparer).Returns(5);
            }
        }

        public static IEnumerable StringArrayBinarySearchDelegateTestData
        {
            get
            {
                string[] testArray = { "U", "v", "W", "X", "y", "Z" };

                var comparer = new StringComparer();

                Comparison<string> comparison = (e, f) => comparer.Compare(e, f);

                yield return new TestCaseData(testArray, "x", comparison).Returns(3);
                yield return new TestCaseData(testArray, "U", comparison).Returns(0);
                yield return new TestCaseData(testArray, "F", comparison).Returns(-1);
                yield return new TestCaseData(testArray, "z", comparison).Returns(5);
            }
        }

        #endregion

        #region Private comparer classes

        private class IntComparer : IComparer<int>
        {
            public int Compare(int first, int second)
            {
                return first.CompareTo(second);
            }
        }

        private class StringComparer : IComparer<string>
        {
            public int Compare(string first, string second)
            {
                return string.Compare(first, second, StringComparison.CurrentCultureIgnoreCase);
            }
        }

        #endregion

    }
}

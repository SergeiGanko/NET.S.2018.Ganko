using NUnit.Framework;
using System;
using static WorkingWithJaggedArray.BubbleSorterWithDelegateImplementation;
using System.Collections.Generic;

namespace WorkingWithJaggedArray.Tests
{
    [TestFixture]
    public class BubbleSorterWithDelegateTests
    {
        [Test]
        public void Sort_BySumAscending()
        {
            int[][] testArray =
            {
                new[] { 4, 1, 5 },
                new[] { 7, 2 },
                null,
                null,
                new[] { 3, 1, 6, 2 }
            };

            var jaggedArrayBySumAsc = new JaggedArrayBySumAscendingSorter();

            Func<int[], int[], int> comparisonFunc = jaggedArrayBySumAsc.Compare;

            int[][] expectedArray =
            {
                new[] { 7, 2 },
                new[] { 4, 1, 5 },
                new[] { 3, 1, 6, 2 },
                null,
                null
            };

            Sort(testArray, comparisonFunc);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_BySumDescending()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5, },
                    null,
                    new[] { 7, 2 },
                    null,
                    new[] { 3, 1, 6, 2 },
                };

            var jaggedArrayBySumDesc = new JaggedArrayBySumDescendingSorter();

            int[][] expectedArray =
                {
                    new[] { 3, 1, 6, 2 },
                    new[] { 4, 1, 5 },
                    new[] { 7, 2 },
                    null,
                    null
                };

            Sort(testArray, jaggedArrayBySumDesc);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_ByMaxAscending()
        {
            int[][] testArray =
                {
                    null,
                    null,
                    new[] { 4, 1, 5 },
                    new[] { 7, 2 },
                    new[] { 3, 1, 6, 2 }
                };

            var jaggedArrayByMaxAsc = new JaggedArrayByMaxAscendingSorter();

            Func<int[], int[], int> comparisonFunc = jaggedArrayByMaxAsc.Compare;

            int[][] expectedArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 3, 1, 6, 2 },
                    new[] { 7, 2 },
                    null,
                    null
                };

            Sort(testArray, comparisonFunc);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_ByMaxDescending()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5 },
                    null,
                    new[] { 7, 2 },
                    new[] { 3, 1, 6, 2 }
                };

            var jaggedArrayByMaxDesc = new JaggedArrayByMaxDescendingSorter();

            int[][] expectedArray =
                {
                    new[] { 7, 2 },
                    new[] { 3, 1, 6, 2 },
                    new[] { 4, 1, 5 },
                    null
                };

            Sort(testArray, jaggedArrayByMaxDesc);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_ByMinAscending()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5, },
                    new[] { 7, 2 },
                    null,
                    new[] { 3, 1, 6, 2 },
                };

            var jaggedArrayByMinAsc = new JaggedArrayByMinAscendingSorter();

            Func<int[], int[], int> comparisonFunc = jaggedArrayByMinAsc.Compare;

            int[][] expectedArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 3, 1, 6, 2 },
                    new[] { 7, 2 },
                    null
                };

            Sort(testArray, comparisonFunc);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_ByMinDescending()
        {
            int[][] testArray =
                {
                    null,
                    new[] { 4, 2, 5, },
                    new[] { 7, 3 },
                    new[] { 3, 1, 6, 2 },
                };

            var jaggedArrayByMinDesc = new JaggedArrayByMinDescendingSorter();

            int[][] expectedArray =
                {
                    new[] { 7, 3 },
                    new[] { 4, 2, 5 },
                    new[] { 3, 1, 6, 2 },
                    null
                };

            Sort(testArray, jaggedArrayByMinDesc);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_PassNullInsteadArray_ExpectArgumentNullException()
        {
            IComparer<int[]> comparer = null;
            Assert.Throws<ArgumentNullException>(() => Sort(null, comparer));
        }

        [Test]
        public void Sort_PassNullEnsteadComparer_ExpectArgumentNullException()
        {
            var testArray = new int[][] { new[] { 1, 2 }, new[] { 5, 6 } };
            IComparer<int[]> comparer = null;

            Assert.Throws<ArgumentNullException>(() => Sort(testArray, comparer));
        }
    }
}

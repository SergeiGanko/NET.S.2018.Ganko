using NUnit.Framework;
using System;
using static WorkingWithJaggedArray.BubbleSorter;

namespace WorkingWithJaggedArray.Tests
{
    [TestFixture]
    public class BubbleSorterTests
    {
        [Test]
        public void Sort_BySumAscending()
        {
            int[][] testArray =
            {
                new[] { 4, 1, 5 },
                new[] { 7, 2 },
                new[] { 3, 1, 6, 2 }
            };

            var jaggedArrayBySum = new JaggedArrayBySumSorter();

            int[][] expectedArray =
            {
                new[] { 7, 2 },
                new[] { 4, 1, 5 },
                new[] { 3, 1, 6, 2 }
            };

            Sort(testArray, jaggedArrayBySum, Order.Ascending);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_BySumDescending()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5, },
                    new[] { 7, 2 },
                    new[] { 3, 1, 6, 2 },
                };

            var jaggedArrayBySum = new JaggedArrayBySumSorter();

            int[][] expectedArray =
                {
                    new[] { 3, 1, 6, 2 },
                    new[] { 4, 1, 5 },
                    new[] { 7, 2 }
                };

            Sort(testArray, jaggedArrayBySum, Order.Descending);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_ByMaxAscending()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 7, 2 },
                    new[] { 3, 1, 6, 2 }
                };

            var jaggedArrayByMax = new JaggedArrayByMaxSorter();

            int[][] expectedArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 3, 1, 6, 2 },
                    new[] { 7, 2 }
                };

            Sort(testArray, jaggedArrayByMax, Order.Ascending);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_ByMaxDescending()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 7, 2 },
                    new[] { 3, 1, 6, 2 }
                };

            var jaggedArrayByMax = new JaggedArrayByMaxSorter();

            int[][] expectedArray =
                {
                    new[] { 7, 2 },
                    new[] { 3, 1, 6, 2 },
                    new[] { 4, 1, 5 }
                };

            Sort(testArray, jaggedArrayByMax, Order.Descending);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_ByMinAscending()
        {
            int[][] testArray =
                {
                    new[] { 4, 1, 5, },
                    new[] { 7, 2 },
                    new[] { 3, 1, 6, 2 },
                };

            var jaggedArrayByMin = new JaggedArrayByMinSorter();

            int[][] expectedArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 3, 1, 6, 2 },
                    new[] { 7, 2 }
                };

            Sort(testArray, jaggedArrayByMin, Order.Ascending);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_ByMinDescending()
        {
            int[][] testArray =
                {
                    new[] { 4, 2, 5, },
                    new[] { 7, 3 },
                    new[] { 3, 1, 6, 2 },
                };

            var jaggedArrayByMin = new JaggedArrayByMinSorter();

            int[][] expectedArray =
                {
                    new[] { 7, 3 },
                    new[] { 4, 2, 5 },
                    new[] { 3, 1, 6, 2 }
                };

            Sort(testArray, jaggedArrayByMin, Order.Descending);

            CollectionAssert.AreEqual(testArray, expectedArray);
        }

        [Test]
        public void Sort_PassNullInsteadArray_ExpectArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Sort(null, null, Order.Ascending));
        }

        [Test]
        public void Sort_PassNullEnsteadComparer_ExpectArgumentNullException()
        {
            var testArray = new int[][] { new[] { 1, 2 }, new[] { 5, 6 } };

            Assert.Throws<ArgumentNullException>(() => Sort(testArray, null, Order.Ascending));
        }
    }
}

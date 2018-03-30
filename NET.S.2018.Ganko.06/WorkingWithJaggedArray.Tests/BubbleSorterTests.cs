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
                null,
                null,
                new[] { 3, 1, 6, 2 }
            };

            var jaggedArrayBySumAsc = new JaggedArrayBySumAscendingSorter();

            int[][] expectedArray =
            {
                new[] { 7, 2 },
                new[] { 4, 1, 5 },
                new[] { 3, 1, 6, 2 },
                null,
                null
            };

            Sort(testArray, jaggedArrayBySumAsc);

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

            int[][] expectedArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 3, 1, 6, 2 },
                    new[] { 7, 2 },
                    null,
                    null
                };

            Sort(testArray, jaggedArrayByMaxAsc);

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

            int[][] expectedArray =
                {
                    new[] { 4, 1, 5 },
                    new[] { 3, 1, 6, 2 },
                    new[] { 7, 2 },
                    null
                };

            Sort(testArray, jaggedArrayByMinAsc);

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
            Assert.Throws<ArgumentNullException>(() => Sort(null, null));
        }

        [Test]
        public void Sort_PassNullEnsteadComparer_ExpectArgumentNullException()
        {
            var testArray = new int[][] { new[] { 1, 2 }, new[] { 5, 6 } };

            Assert.Throws<ArgumentNullException>(() => Sort(testArray, null));
        }
    }
}

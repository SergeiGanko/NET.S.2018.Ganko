using System;
using System.Collections.Generic;

namespace SortAlgorithms.Tests
{
    /// <summary>
    /// TestArraysInitializer class
    /// </summary>
    public static class TestArraysInitializer
    {
        #region Private Fields

        /// <summary>
        /// The get random
        /// </summary>
        private static readonly Random getRandom = new Random();

        /// <summary>
        /// The actual result array
        /// </summary>
        private static int[] actualResultArray;

        /// <summary>
        /// The expect result array
        /// </summary>
        private static int[] expectResultArray;

        #endregion

        #region Public Properties and Methods

        /// <summary>
        /// Gets the actual result array.
        /// </summary>
        /// <value>
        /// The actual result array.
        /// </value>
        public static int[] ActualResultArray => actualResultArray;

        /// <summary>
        /// Gets the expect result array.
        /// </summary>
        /// <value>
        /// The expect result array.
        /// </value>
        public static int[] ExpectResultArray => expectResultArray;

        /// <summary>
        /// Initializes the actual result array and expect result array.
        /// </summary>
        /// <param name="n">Array dimension</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public static void InitializeActualResultArrayAndExpectResultArray(int n, int minValue, int maxValue)
        {
            List<int> randomList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                randomList.Add(GetRandom(minValue, maxValue));
            }

            actualResultArray = randomList.ToArray();
            randomList.Sort();
            expectResultArray = randomList.ToArray();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the random.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>Returns a random value of int.</returns>
        private static int GetRandom(int min, int max)
        {
            return getRandom.Next(min, max);
        }

        #endregion
    }
}

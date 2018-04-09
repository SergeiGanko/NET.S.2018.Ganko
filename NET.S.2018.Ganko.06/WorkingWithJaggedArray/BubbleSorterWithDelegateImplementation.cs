using System;
using System.Collections.Generic;

namespace WorkingWithJaggedArray
{
    /// <summary>
    /// Bubble sorter class
    /// </summary>
    public class BubbleSorterWithDelegateImplementation
    {
        /// <summary>
        /// Sorts jagged array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            CheckInput(array, comparer);

            Func<int[], int[], int> comparisonDelegate = comparer.Compare;

            Sort(array, comparisonDelegate);
        }

        /// <summary>
        /// Sorts jagged array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Sort(int[][] array, Func<int[], int[], int> comparer)
        {
            CheckInput(array, comparer);

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        #region private methods

        /// <summary>
        /// Swaps two arrays.
        /// </summary>
        /// <param name="first">The first array.</param>
        /// <param name="second">The second array.</param>
        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Throws when input array is null or comparer is null</exception>
        private static void CheckInput(int[][] array, IComparer<int[]> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Argument {nameof(array)} is null");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"Argument {nameof(comparer)} is null");
            }
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Throws when input array is null or comparer is null</exception>
        private static void CheckInput(int[][] array, Func<int[], int[], int> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Argument {nameof(array)} is null");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"Argument {nameof(comparer)} is null");
            }
        }

        #endregion
    }
}

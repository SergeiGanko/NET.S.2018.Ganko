using System;
using System.Collections.Generic;

namespace WorkingWithJaggedArray
{
    /// <summary>
    /// Bubble sorter class
    /// </summary>
    public static class BubbleSorter
    {
        /// <summary>
        /// Sorts jagged array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">
        /// array
        /// or
        /// comparer
        /// </exception>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Argument {nameof(array)} is null");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"Argument {nameof(comparer)} is null");
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

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
    }
}

using System;
using System.Collections.Generic;

namespace WorkingWithJaggedArray
{
    /// <summary>
    /// Bubble sorter class
    /// </summary>
    public static class BubbleSorterWithInterfaceImplementation
    {
        /// <summary>
        /// Sorts jagged array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            CheckInput(array, comparer);

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
        /// Sorts jagged array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Sort(int[][] array, Func<int[], int[], int> comparer)
        {
            CheckInput(array, comparer);

            Sort(array, new DelegateToInterfaceAdapter(comparer));
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

        #region Adapter classes

        /// <summary>
        /// Delegate to Interface adapter
        /// </summary>
        private sealed class DelegateToInterfaceAdapter : IComparer<int[]>
        {
            /// <summary>
            /// The comparer
            /// </summary>
            private readonly Func<int[], int[], int> comparer;

            /// <summary>
            /// Initializes a new instance of the <see cref="DelegateToInterfaceAdapter"/> class.
            /// </summary>
            /// <param name="comparer">The comparer.</param>
            public DelegateToInterfaceAdapter(Func<int[], int[], int> comparer)
            {
                this.comparer = comparer;
            }

            /// <summary>
            /// Compares two arrays.
            /// </summary>
            /// <param name="firstArray">The first array.</param>
            /// <param name="secondArray">The second array.</param>
            /// <returns>Returns value which indicating comparison of two arrays</returns>
            public int Compare(int[] firstArray, int[] secondArray)
            {
                return this.comparer(firstArray, secondArray);
            }
        }

        #endregion
    }
}

using System;

namespace SortAlgorithms
{
    /// <summary>
    /// QuickSorter class
    /// </summary>
    public static class QuickSorter
    {
        /// <summary>
        /// Receives an input array and calls overloaded version of method QuickSort with 3 parameters
        /// </summary>
        /// <param name="input">Array of ints</param>
        public static void QuickSort(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"input is null");
            }

            if (input.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            QuickSort(input, 0, input.Length - 1);
        }

        /// <summary>
        /// Method sorts array of ints
        /// </summary>
        /// <param name="input">Array of ints</param>
        /// <param name="left">The first index of array</param>
        /// <param name="right">The last index of array</param>
        private static void QuickSort(int[] input, int left, int right)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"input is null");
            }

            if (input.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            if (left > right || left < 0 || right < 0 || right > input.Length - 1)
            {
                throw new ArgumentException("One of the arguments provided to the method is not valid");
            }

            int i = left;
            int j = right;
            int pivot = input[(left + right) / 2];

            while (i <= j)
            {
                while (input[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (input[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = input[i];
                    input[i] = input[j];
                    input[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(input, left, j);
            }

            if (i < right)
            {
                QuickSort(input, i, right);
            }
        }
    }
}

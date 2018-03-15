using System;

namespace SortAlgorithms
{
    /// <summary>
    /// MergeSorter class
    /// </summary>
    public static class MergeSorter
    {
        /// <summary>
        /// Receives an input array and calls overloaded version of method MergeSort with 3 parameters
        /// </summary>
        /// <param name="input">Input array</param>
        public static void MergeSort(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"Input is null");
            }

            if (input.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            MergeSort(input, 0, input.Length);
        }

        /// <summary>
        /// Sorts left half of array, sorts right half of array and calls method Merge
        /// </summary>
        /// <param name="input">Input array</param>
        /// <param name="left">First index of input array</param>
        /// <param name="right">Last index of input array</param>
        private static void MergeSort(int[] input, int left, int right)
        {
            int n = right - left;
            if (n < 2)
            {
                return;
            }

            int middle = left + (n / 2);

            MergeSort(input, left, middle);
            MergeSort(input, middle, right);

            int[] temp = new int[n];

            Merge(input, temp, left, middle, right);
        }

        /// <summary>
        /// Merges left and right parts of array
        /// </summary>
        /// <param name="input">Input array</param>
        /// <param name="temp">Temporary array</param>
        /// <param name="left">First index of input array</param>
        /// <param name="middle">Middle index of input array</param>
        /// <param name="right">Last index of input array</param>
        private static void Merge(int[] input, int[] temp, int left, int middle, int right)
        {
            int i = left;
            int j = middle;

            for (int k = 0; k < temp.Length; k++)
            {
                if (i == middle)
                {
                    temp[k] = input[j];
                    j++;
                }
                else if (j == right)
                {
                    temp[k] = input[i];
                    i++;
                }
                else if (input[j].CompareTo(input[i]) < 0)
                {
                    temp[k] = input[j];
                    j++;
                }
                else
                {
                    temp[k] = input[i];
                    i++;
                }
            }

            // Rewrites from temp array to input array
            for (int k = 0; k < temp.Length; k++)
            {
                input[left + k] = temp[k];
            }
        }
    }
}

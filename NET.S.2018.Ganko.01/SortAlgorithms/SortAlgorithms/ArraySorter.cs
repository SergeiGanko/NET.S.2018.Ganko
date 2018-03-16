using System;

namespace SortAlgorithms
{
    /// <summary>
    /// ArraySorter class
    /// </summary>
    public static class ArraySorter
    {
        #region MergeSort Public Members

        /// <summary>
        /// Receives an input array and calls overloaded version of method MergeSort with 3 parameters
        /// </summary>
        /// <param name="input">Input array</param>
        public static void MergeSort(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"{nameof(input)} is null");
            }

            MergeSort(input, 0, input.Length);
        }

        #endregion

        #region QuickSort Public Members

        /// <summary>
        /// Receives an input array and calls overloaded version of method QuickSort with 3 parameters
        /// </summary>
        /// <param name="input">Array of ints</param>
        public static void QuickSort(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"{nameof(input)} is null");
            }

            QuickSort(input, 0, input.Length - 1);
        }

        #endregion

        #region MergeSort Private Members

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

        #endregion

        #region QuickSort Private Members

        /// <summary>
        /// Method sorts array of ints
        /// </summary>
        /// <param name="input">Array of ints</param>
        /// <param name="left">The first index of array</param>
        /// <param name="right">The last index of array</param>
        private static void QuickSort(int[] input, int left, int right)
        {
            if (input.Length < 2)
            {
                return;
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

        #endregion
    }
}

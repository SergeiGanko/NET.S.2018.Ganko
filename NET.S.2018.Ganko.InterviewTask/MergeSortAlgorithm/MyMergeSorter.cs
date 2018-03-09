// <copyright file="MyMergeSorter.cs" company="Sergei Ganko">
//     Copyright (c) Sergei Ganko. All rights reserved.
// </copyright>
// <author>Sergei Ganko</author>
namespace MergeSortAlgorithm
{
    using System;

    /// <summary>
    /// The MyMergeSorter class.
    /// Contains all methods for performing merge sorting.
    /// </summary>
    public static class MyMergeSorter
    {
        /// <summary>
        /// Receives an input array and calls overload version of method MergeSort with 3 parameters
        /// </summary>
        /// <typeparam name="T">Represents type which implements IComparable<typeparamref name="T"/></typeparam>
        /// <param name="input">Input array</param>
        public static void MergeSort<T>(T[] input) where T : IComparable<T>
        {
            MergeSort(input, 0, input.Length);
        }

        /// <summary>
        /// Sorts left half of array, sorts right half of array and calls method Merge
        /// </summary>
        /// <typeparam name="T">Represents type which implements IComparable<typeparamref name="T"/></typeparam>
        /// <param name="input">Input array</param>
        /// <param name="left">First index of input array</param>
        /// <param name="right">Last index of input array</param>
        public static void MergeSort<T>(T[] input, int left, int right) 
            where T : IComparable<T>
        {
            int n = right - left; 
            if (n < 2)
            {
                return;
            }

            int middle = left + (n / 2);

            MergeSort(input, left, middle);
            MergeSort(input, middle, right);

            T[] temp = new T[n];

            Merge(input, temp, left, middle, right);
        }

        /// <summary>
        /// Merges left and right parts of array
        /// </summary>
        /// <typeparam name="T">Represents type which implements IComparable<typeparamref name="T"/></typeparam>
        /// <param name="input">Input array</param>
        /// <param name="temp">Temporary array</param>
        /// <param name="left">First index of input array</param>
        /// <param name="middle">Middle index of input array</param>
        /// <param name="right">Last index of input array</param>
        private static void Merge<T>(T[] input, T[] temp, int left, int middle, int right) 
            where T : IComparable<T>
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

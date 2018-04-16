using System;
using System.Collections.Generic;

namespace BinarySearch
{
    /// <summary>
    /// BinarySearcher Class
    /// </summary>
    public sealed class BinarySearcher
    {
        /// <summary>
        /// Searches the entire sorted array for an element 'item' using the comparer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="item">The item.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Returns the index of the element</returns>
        public static int BinarySearch<T>(T[] array, T item, IComparer<T> comparer)
        {
            return BinarySearch(array, item, comparer.Compare);
        }

        /// <summary>
        /// Searches the entire sorted array for an element 'item' using the comparison.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="item">The item.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns>Returns the index of the element</returns>
        /// <exception cref="System.InvalidOperationException">Throws when two objects can't be compared</exception>
        public static int BinarySearch<T>(T[] array, T item, Comparison<T> comparison)
        {
            CheckInput(array, item);

            if (comparison == null)
            {
                if (item is IComparable<T> element)
                {
                    comparison = (T first, T second) => element.CompareTo(second);
                }
                else
                {
                    throw new InvalidOperationException($"Objects of type {nameof(T)} can't be compared");
                }
            }

            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (comparison(item, array[mid]) <= 0)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (comparison(item, array[left]) == 0)
            {
                return left;
            }

            return -1;
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="item">The item.</param>
        /// <exception cref="System.ArgumentNullException">Throws when array or item is null
        /// </exception>
        private static void CheckInput<T>(T[] array, T item)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Argument {nameof(array)} is null");
            }

            if (item == null)
            {
                throw new ArgumentNullException($"Argument {nameof(item)} is null");
            }
        }
    }
}

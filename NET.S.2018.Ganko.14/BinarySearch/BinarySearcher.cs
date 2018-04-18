using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    /// <summary>
    /// BinarySearcher Class
    /// </summary>
    public static class BinarySearcher
    {
        /// <summary>
        /// Searches the entire sorted array for an element 'item' using the comparer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The array.</param>
        /// <param name="item">The item.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Returns the index of the element</returns>
        public static int BinarySearch<T>(this IEnumerable<T> collection, T item, IComparer<T> comparer)
        {
            CheckInput(collection, item);

            return BinarySearch(collection, item, comparer.Compare);
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
        public static int BinarySearch<T>(this IEnumerable<T> collection, T item, Comparison<T> comparison)
        {
            CheckInput(collection, item);

            if (comparison == null)
            {
                if (item is IComparable<T> element)
                {
                    comparison = (first, second) => element.CompareTo(second);
                }
                else
                {
                    throw new InvalidOperationException($"Objects of type {nameof(T)} can't be compared");
                }
            }

            int left = 0;
            int right = collection.Count();

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (comparison(item, collection.ElementAt(mid)) <= 0)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (comparison(item, collection.ElementAt(left)) == 0)
            {
                return left;
            }

            return -1;
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="item">The item.</param>
        /// <exception cref="System.ArgumentNullException">Throws when array or item is null
        /// </exception>
        private static void CheckInput<T>(IEnumerable<T> collection, T item)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"Argument {nameof(collection)} is null");
            }

            if (item == null)
            {
                throw new ArgumentNullException($"Argument {nameof(item)} is null");
            }
        }
    }
}

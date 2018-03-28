using System;
using System.Collections.Generic;

namespace WorkingWithJaggedArray
{
    public static class BubbleSorter
    {
        public static void Sort(int[][] array, IComparer<int[]> comparer, Order order)
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
                    switch (order)
                    {
                        case Order.Ascending:
                            {
                                if (comparer.Compare(array[j], array[j + 1]) > 0)
                                {
                                    Swap(ref array[j], ref array[j + 1]);
                                }
                            }
                            break;
                        case Order.Descending:
                            {
                                if (comparer.Compare(array[j], array[j + 1]) < 0)
                                {
                                    Swap(ref array[j], ref array[j + 1]);
                                }
                            }
                            break;
                    }
                }
            }
        }

        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
    }
}

﻿using System.Collections.Generic;
using System.Linq;

namespace WorkingWithJaggedArray.Tests
{
    public sealed class JaggedArrayByMaxAscendingSorter : IComparer<int[]>
    {
        public int Compare(int[] firstArray, int[] secondArray)
        {
            if (firstArray == null && secondArray == null)
            {
                return 0;
            }

            if (firstArray == null)
            {
                return 1;
            }

            if (secondArray == null)
            {
                return -1;
            }

            return firstArray.Max().CompareTo(secondArray.Max());
        }
    }
}

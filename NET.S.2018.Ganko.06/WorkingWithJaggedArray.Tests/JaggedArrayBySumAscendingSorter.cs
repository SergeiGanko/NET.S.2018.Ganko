using System.Collections.Generic;
using System.Linq;

namespace WorkingWithJaggedArray.Tests
{
    public sealed class JaggedArrayBySumAscendingSorter : IComparer<int[]>
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

            //int firstArraySum = ArrayHelper.GetSum(firstArray);
            //int secondArraySum = ArrayHelper.GetSum(secondArray);

            //if (firstArraySum > secondArraySum)
            //{
            //    return 1;
            //}

            //if (firstArraySum < secondArraySum)
            //{
            //    return -1;
            //}

            return firstArray.Sum().CompareTo(secondArray.Sum());
        }
    }
}

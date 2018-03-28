using System.Collections.Generic;

namespace WorkingWithJaggedArray
{
    public sealed class JaggedArrayBySumSorter : IComparer<int[]>
    {
        public int Compare(int[] firstArray, int[] secondArray)
        {
            int firstArraySum = ArrayHelper.GetSum(firstArray);
            int secondArraySum = ArrayHelper.GetSum(secondArray);

            if (firstArraySum > secondArraySum)
            {
                return 1;
            }

            if (firstArraySum < secondArraySum)
            {
                return -1;
            }

            return 0;
        }
    }
}

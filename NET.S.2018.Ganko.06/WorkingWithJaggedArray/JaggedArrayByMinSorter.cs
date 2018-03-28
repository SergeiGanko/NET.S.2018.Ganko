using System.Collections.Generic;

namespace WorkingWithJaggedArray
{
    public sealed class JaggedArrayByMinSorter : IComparer<int[]>
    {
        public int Compare(int[] firstArray, int[] secondArray)
        {
            int minOfFirstArray = ArrayHelper.GetMin(firstArray);
            int minOfSecondArray = ArrayHelper.GetMin(secondArray);

            if (minOfFirstArray > minOfSecondArray)
            {
                return 1;
            }

            if (minOfFirstArray < minOfSecondArray)
            {
                return -1;
            }

            return 0;
        }
    }
}

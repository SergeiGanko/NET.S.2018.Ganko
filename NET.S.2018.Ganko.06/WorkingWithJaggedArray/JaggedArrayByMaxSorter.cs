using System.Collections.Generic;

namespace WorkingWithJaggedArray
{
    public sealed class JaggedArrayByMaxSorter : IComparer<int[]>
    {
        public int Compare(int[] firstArray, int[] secondArray)
        {
            int maxOfFirstArray = ArrayHelper.GetMax(firstArray);
            int maxOfSecondArray = ArrayHelper.GetMax(secondArray);

            if (maxOfFirstArray > maxOfSecondArray)
            {
                return 1;
            }

            if (maxOfFirstArray < maxOfSecondArray)
            {
                return -1;
            }

            return 0;
        }
    }
}

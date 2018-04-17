using System.Collections.Generic;

namespace SearchAlgorithm.Tests.Comparers
{
    public sealed class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}

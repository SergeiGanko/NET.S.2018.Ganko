using System.Collections.Generic;

namespace SearchAlgorithm.Tests.Comparers
{
    public sealed class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return y.CompareTo(x);
        }
    }
}

using System.Collections.Generic;

namespace SearchAlgorithm.Tests.Comparers
{
    public sealed class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return (x.x * x.y).CompareTo(y.x * y.y);
        }
    }
}

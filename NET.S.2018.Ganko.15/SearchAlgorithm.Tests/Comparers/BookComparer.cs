using System.Collections.Generic;

namespace SearchAlgorithm.Tests.Comparers
{
    public sealed class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}

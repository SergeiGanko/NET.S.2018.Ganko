using System.Collections.Generic;
using Books;

namespace BooksAppCUI
{
    public class YearComparer : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook == null && secondBook == null)
            {
                return 0;
            }

            if (firstBook == null)
            {
                return 1;
            }

            if (secondBook == null)
            {
                return -1;
            }

            return firstBook.PublishingYear.CompareTo(secondBook.PublishingYear);
        }
    }
}

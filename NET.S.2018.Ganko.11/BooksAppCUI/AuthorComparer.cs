using System;
using System.Collections.Generic;
using Books;

namespace BooksAppCUI
{
    public class AuthorComparer : IComparer<Book>
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

            return String.Compare(firstBook.Author, secondBook.Author, StringComparison.CurrentCulture);
        }
    }
}

using Books;
using Books.Service;

namespace BooksAppCUI
{
    public class AuthorPredicate : IPredicate<Book>
    {
        public string Author { get; set; }

        public bool isMatch(Book book)
        {
            return book.Author == this.Author;
        }
    }
}

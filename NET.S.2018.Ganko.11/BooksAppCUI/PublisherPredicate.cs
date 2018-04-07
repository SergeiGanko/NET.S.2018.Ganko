using Books;
using Books.Service;

namespace BooksAppCUI
{
    public class PublisherPredicate : IPredicate<Book>
    {
        public string Publisher { get; set; }

        public bool isMatch(Book book)
        {
            return book.Publisher == this.Publisher;
        }
    }
}

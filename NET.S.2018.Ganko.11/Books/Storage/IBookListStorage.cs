using System.Collections.Generic;

namespace Books.Storage
{
    public interface IBookListStorage
    {
        IEnumerable<Book> LoadBooks();

        void SaveBooks(IEnumerable<Book> books);
    }
}
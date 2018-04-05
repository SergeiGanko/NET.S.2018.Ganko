namespace Books.Storage
{
    using System.Collections.Generic;

    public interface IBookListStorage
    {
        ICollection<Book> LoadBooks();

        void SaveBooks(ICollection<Book> books);
    }
}
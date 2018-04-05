using System;
using System.Collections.Generic;
using Books.Storage;
using System.Linq;

namespace Books.Service
{
    public sealed class BookListService
    {
        private IBookListStorage storage;

        private List<Book> books;

        public BookListService(IBookListStorage storage)
        {
            this.storage = storage;
            this.books = new List<Book>(storage.LoadBooks());
        }

        public BookListService(ICollection<Book> books)
        {
            //this.books = new List<Book>(books.Where(b => b != null));
            this.books = new List<Book>(books);
        }

        public IBookListStorage Storage { get; set; }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException($"Argument {nameof(book)} is null");
            }

            if (books.Contains(book))
            {
                throw new Exception($"The book {book.Title} is already exists.");
            }

            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException($"Argument {nameof(book)} is null");
            }

            if (!books.Contains(book))
            {
                throw new Exception($"The book not found");
            }

            books.Remove(book);
        }

        public Book FindBookByTag(Predicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                throw new ArgumentNullException($"Argument {nameof(predicate)} is null");
            }

            return books.Find(predicate);
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException($"Argument {nameof(comparer)} is null");
            }

            books.Sort(comparer);
        }
    }
}

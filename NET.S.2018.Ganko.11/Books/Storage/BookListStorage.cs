using System;
using System.Collections.Generic;
using System.IO;

namespace Books.Storage
{
    /// <summary>
    /// The book storage
    /// </summary>
    /// <seealso cref="Books.Storage.IBookListStorage" />
    public class BookListStorage : IBookListStorage
    {
        /// <summary>
        /// The file path
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListStorage"/> class.
        /// </summary>
        /// <param name="path">The file path</param>
        /// <exception cref="ArgumentException">Throws when file path is null or empty or whitespace</exception>
        public BookListStorage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"Invalid argument {nameof(path)}");
            }

            this.path = path;
        }

        /// <summary>
        /// Loads the books.
        /// </summary>
        /// <returns>Returns collection of books</returns>
        /// <exception cref="InvalidOperationException">Throws when file not found.</exception>
        public IEnumerable<Book> LoadBooks()
        {
            if (!File.Exists(path))
            {
                throw new InvalidOperationException("File not found.");
            }

            var books = new List<Book>();

            using (var fs = File.OpenRead(path))
            {
                using (var reader = new BinaryReader(fs))
                {
                    while (reader.PeekChar() > -1)
                    {
                        books.Add(new Book(
                            isbn: reader.ReadString(),
                            author: reader.ReadString(),
                            title: reader.ReadString(),
                            publisher: reader.ReadString(),
                            year: reader.ReadInt32(),
                            pages: reader.ReadInt32(),
                            price: reader.ReadDecimal()));
                    }
                }
            }

            return books;
        }

        /// <summary>
        /// Saves the books.
        /// </summary>
        /// <param name="books">The collection of books</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            using (var fs = File.Create(path))
            {
                using (var writer = new BinaryWriter(fs))
                {
                    foreach (var book in books)
                    {
                        writer.Write(book.Isbn);
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Publisher);
                        writer.Write(book.PublishingYear);
                        writer.Write(book.PagesNumber);
                        writer.Write(book.Price);
                    }
                }
            }
        }
    }
}

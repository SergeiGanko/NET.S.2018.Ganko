using System;
using System.Collections.Generic;
using System.IO;

namespace Books.Storage
{
    public class BookListStorage : IBookListStorage
    {
        private readonly string path;

        public BookListStorage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"Invalid argument {nameof(path)}");
            }

            this.path = path;
        }

        public ICollection<Book> LoadBooks()
        {
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

        public void SaveBooks(ICollection<Book> books)
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

using System;
using System.Collections.Generic;
using Books.CustomException;
using Books.Storage;
using Books.Log;

namespace Books.Service
{
    /// <summary>
    /// The BookListService class
    /// </summary>
    public sealed class BookListService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">Throws when logger is null</exception>
        public BookListService(ILogger logger)
        {
            if (ReferenceEquals(logger, null))
            {
                throw new ArgumentNullException($"Argument {nameof(logger)} is null");
            }

            this.logger = logger;

            Books = new SortedSet<Book>();

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="books">The books.</param>
        /// <param name="logger">The logger.</param>
        public BookListService(IEnumerable<Book> books, ILogger logger) : this(logger)
        {
            foreach (var book in books)
            {
                if (!ReferenceEquals(book, null))
                {
                    Books.Add(book);
                }
            }
        }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        public SortedSet<Book> Books { get; set; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        public ILogger Logger => this.logger;

        /// <summary>
        /// Adds the book to the list.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <exception cref="ArgumentNullException">Throw when the book is null</exception>
        /// <exception cref="BookAlreadyExistException">Throws when the book is already exists in the list</exception>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException($"Argument {nameof(book)} is null");
            }
            
            if (!Books.Add(book))
            {
                throw new BookAlreadyExistException($"The book {book.Title} is already exists.");
            }

            logger.Debug($"The book \"{book.Title}\" added successfully!\n");
        }

        /// <summary>
        /// Removes the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <exception cref="ArgumentNullException">Throw when the book is null</exception>
        /// <exception cref="BookNotFoundException">Throw when the book not found</exception>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException($"Argument {nameof(book)} is null");
            }

            if (!Books.Remove(book))
            {
                throw new BookNotFoundException($"The book not found");
            }

            logger.Debug($"The book \"{book.Title}\" removed successfully!\n");
        }

        /// <summary>
        /// Finds the book by tag.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns book</returns>
        /// <exception cref="ArgumentNullException">Throw when the predicate is null</exception>
        public Book FindBookByTag(IPredicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                throw new ArgumentNullException($"Argument {nameof(predicate)} is null");
            }

            foreach (var book in Books)
            {
                if (predicate.isMatch(book))
                {
                    return book;
                }
            }

            return null;
        }

        /// <summary>
        /// Sorts the books by tag.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Throw when the comparer is null</exception>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException($"Argument {nameof(comparer)} is null");
            }

            Books = new SortedSet<Book>(Books, comparer);
        }

        /// <summary>
        /// Loads from storage.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">Throw when the storage is null</exception>
        public void LoadFromStorage(IBookListStorage storage)
        {
            if (ReferenceEquals(storage, null))
            {
                throw new ArgumentNullException($"Argument {nameof(storage)} is null");
            }

            Books.Clear();

            foreach (var book in storage.LoadBooks())
            {
                AddBook(book);
            }

            logger.Debug($"List of books loaded successfully!\n");
        }

        /// <summary>
        /// Saves the in storage.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">Throw when the storage is null</exception>
        public void SaveInStorage(IBookListStorage storage)
        {
            if (ReferenceEquals(storage, null))
            {
                throw new ArgumentNullException($"Argument {nameof(storage)} is null");
            }

            storage.SaveBooks(Books);

            logger.Debug($"List of books saved successfully!\n");
        }
    }
}

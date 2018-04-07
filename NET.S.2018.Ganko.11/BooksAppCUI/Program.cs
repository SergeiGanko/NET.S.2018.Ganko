using System;
using System.Collections.Generic;
using Books;
using Books.Service;
using Books.Log;
using NLog;
using Books.CustomException;
using Books.Storage;

namespace BooksAppCUI
{
    internal sealed class Program
    {
        private static void Main()
        {
            #region Configure NLog Targets for output programmatically

            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget() { FileName = "file.txt", Name = "logfile" };
            var logconsole = new NLog.Targets.ConsoleTarget() { Name = "logconsole" };

            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Trace, logconsole));
            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Debug, logfile));

            NLog.LogManager.Configuration = config;

            var nLogger = new NLogger();

            #endregion

            #region Creation book instances and adding them to SortedSet

            var books = new SortedSet<Book>
                            {
                                new Book(
                                    "978-0-672-33690-4",
                                    "Bart De Smet",
                                    "C# 5.0 Unleashed",
                                    "SAMS Publishing",
                                    2013,
                                    1671,
                                    51.29m),
                                new Book(
                                    "978-0-735-68320-4",
                                    "Gary McLean Hall",
                                    "Adaptive Code via C#",
                                    "Microsoft Press",
                                    2014,
                                    403,
                                    35.01m),
                                new Book(
                                    "978-1-617-29134-0",
                                    "Jon Skeet",
                                    "C# in Depth, 3rd Edition",
                                    "Manning",
                                    2015,
                                    605,
                                    39.73m),
                                new Book(
                                    "978-1-491-98765-0",
                                    "Joseph Albahari & Веn Albahari",
                                    "C# 7.0 in a Nutshell: The Definitive Reference",
                                    "O'Reilly",
                                    2018,
                                    1140,
                                    60.53m)
                            };

            Console.WriteLine($"*** SortedSet ordered alphabetically by title ***\n");

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            #endregion

            #region Book class testing

            Console.WriteLine($"\n*** Book testing ***\n");

            Console.WriteLine($"\n--- Equals testing ---\n");

            var bookAlbahari2 = new Book("978-1-491-98765-0",
                "Joseph Albahari & Веn Albahari",
                "C# 7.0 in a Nutshell: The Definitive Reference",
                "O'Reilly",
                2018,
                1140,
                60.53m);

            foreach (var book in books)
            {
                if (book.Equals(bookAlbahari2))
                {
                    Console.WriteLine($"{book.ToString()}\n{bookAlbahari2.ToString()}\nThe same books");
                }
            }

            Console.WriteLine($"\n--- GetHashCode testing ---\n");

            foreach (var book in books)
            {
                Console.WriteLine($"Hash - \'{book.GetHashCode()}' --- {book.ToString("AT")}");
            }

            Console.WriteLine($"\nHash - \'{bookAlbahari2.GetHashCode()}' --- {bookAlbahari2.ToString("AT")}");

            #endregion

            #region Book List Service testing

            Console.WriteLine($"\n*** Book Service testing ***\n");

            var bookService = new BookListService(books, nLogger);

            Console.WriteLine($"\n--- Add book (title Mumu) ---\n");

            var anotherBook = new Book("978-1-555-11223-0",
                "Turgenev",
                "Mumu",
                "Unknown",
                1967,
                200,
                10m);

            bookService.AddBook(anotherBook);

            foreach (var book in bookService.Books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine($"\n--- Trying to add null to book list ---\n");

            try
            {
                bookService.AddBook(null);
            }
            catch (ArgumentNullException ex)
            {
                bookService.Logger.Error(ex.Message);
            }


            Console.WriteLine($"\n--- Trying to add book which is already exists ---\n");

            try
            {
                bookService.AddBook(anotherBook);
            }
            catch (BookAlreadyExistException ex)
            {
                bookService.Logger.Error(ex.Message);
            }

            Console.WriteLine($"\n--- Find book by tag (Publisher = Manning) ---\n");

            var publisherPredicate = new PublisherPredicate { Publisher = "Manning" };

            var searchBook = bookService.FindBookByTag(publisherPredicate);

            Console.WriteLine(searchBook);

            Console.WriteLine($"\n--- Sort book by tag (by PublishingYear, ascending) ---\n");

            bookService.SortBooksByTag(new YearComparer());

            foreach (var book in bookService.Books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine($"\n--- Remove book (title = Mumu) ---\n");

            bookService.RemoveBook(anotherBook);

            foreach (var book in bookService.Books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine($"\n--- Remove book (title = Mumu) ---\n");

            #endregion

            #region Book Storage testing

            Console.WriteLine($"\n*** Book Storage testing ***\n");

            Console.WriteLine($"\n--- Saving list of books to the storage ---\n");

            string path = @"storage.txt";

            var storage = new BookListStorage(path);

            bookService.SaveInStorage(storage);

            Console.WriteLine($"\n--- Loading books from the storage ---\n");

            bookService.LoadFromStorage(storage);

            foreach (var book in bookService.Books)
            {
                Console.WriteLine(book);
            }

            #endregion
        }
    }
}

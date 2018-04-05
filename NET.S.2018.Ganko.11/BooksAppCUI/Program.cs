using System;
using System.Collections.Generic;
using Books;
using Books.Service;

namespace BooksAppCUI
{
    using Books.Storage;

    internal sealed class Program
    {
        private static void Main()
        {
            var books = new List<Book>
                            {
                                new Book(
                                    "978-0672336904",
                                    "Bart De Smet",
                                    "C# 5.0 Unleashed",
                                    "SAMS Publishing",
                                    2013,
                                    1671,
                                    51.29m),
                                new Book(
                                    "978-0735683204",
                                    "Gary McLean Hall",
                                    "Adaptive Code via C#: Agile coding with design patterns and SOLID principles",
                                    "Microsoft Press",
                                    2014,
                                    403,
                                    35.01m),
                                new Book(
                                    "978-1617291340",
                                    "Jon Skeet",
                                    "C# in Depth, 3rd Edition",
                                    "Manning",
                                    2014,
                                    605,
                                    39.73m),
                                new Book(
                                    "978-1491987650",
                                    "Joseph Albahari & Веn Albahari, 7th Edition",
                                    "C# 7.0 in a Nutshell: The Definitive Reference",
                                    "O'Reilly",
                                    2018,
                                    1140,
                                    60.53m)
                            };

            var service = new BookListService(new BookListStorage("books.txt"));

            // TODO ..... 
        }
    }
}

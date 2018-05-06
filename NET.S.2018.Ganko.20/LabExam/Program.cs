using System;
using System.Linq;
using System.Windows.Forms;

namespace LabExam
{
    /// <summary>
    /// Class Program represents a console user interface for managing printers
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var manager = PrinterManager.Instance;

            ConsoleKeyInfo consoleKeyInfo;

            do
            {
                Console.WriteLine("\nSelect your choice:");
                Console.WriteLine("1:Add new printer");
                int number = 2;
                
                if (manager.Printers.Any())
                {
                    foreach (var printer in manager.Printers)
                    {
                        Console.WriteLine($"{number++}:Print on {printer}");
                    }
                }

                consoleKeyInfo = Console.ReadKey();

                if (consoleKeyInfo.Key == ConsoleKey.D1)
                {
                    CreatePrinter();
                }

                if (consoleKeyInfo.Key >= ConsoleKey.D2 
                    && consoleKeyInfo.Key <= ConsoleKey.D9)
                {
                    var index = (int)consoleKeyInfo.Key - 50;

                    try
                    {
                        Print(manager.Printers.ElementAt(index));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Printer not found");
                    }
                }
            }
            while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Creates the printer.
        /// </summary>
        private static void CreatePrinter()
        {
            Console.WriteLine("Creating new printer...\n");
            Console.WriteLine("Choose printer model:");
            Console.WriteLine("1. Canon");
            Console.WriteLine("2. Epson");
            var consoleKeyInfo = Console.ReadKey();
            Console.WriteLine("Enter printer model:");
            var model = Console.ReadLine();

            Printer newPrinter;
            var manager = PrinterManager.Instance;

            if (consoleKeyInfo.Key == ConsoleKey.D1)
            {
                newPrinter = PrinterFactory.CreatePrinter("Canon", model);
            }
            else if (consoleKeyInfo.Key == ConsoleKey.D2)
            {
                newPrinter = PrinterFactory.CreatePrinter("Epson", model);
            }
            else
            {
                return;
            }

            manager.Add(newPrinter);
        }

        /// <summary>
        /// Prints on the specified printer.
        /// </summary>
        /// <param name="printer">The printer.</param>
        private static void Print(Printer printer)
        {
            var manager = PrinterManager.Instance;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.ShowDialog();
                manager.Print(printer, openFileDialog.FileName);
            }
        }
    }
}

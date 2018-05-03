using System;
using System.Linq;

namespace LabExam
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main()
        {
            var manager = PrinterManager.Instance;

            ConsoleKeyInfo consoleKeyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("Select your choice:");
                Console.WriteLine("1:Add new printer");
                int number = 2;
                
                if (PrinterManager.Printers.Any())
                {
                    foreach (var printer in PrinterManager.Printers)
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
                        Print(PrinterManager.Printers.ElementAt(index));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Printer not found");
                    }
                }
            }
            while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }

        private static void CreatePrinter()
        {
            Console.Clear();
            Console.WriteLine("Creating new printer...\n");
            Console.WriteLine("Enter printer name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            var model = Console.ReadLine();

            var newPrinter = new Printer(name, model);

            if (!PrinterManager.Add(newPrinter))
            {
                Console.WriteLine("Printer already exists");
            }
        }

        private static void Print(Printer printer)
        {
            string path = @"log.txt";
            PrinterManager.Print(printer, path);
        }
    }
}

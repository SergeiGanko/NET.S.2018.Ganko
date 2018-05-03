using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    internal sealed class PrinterManager
    {
        private static readonly Lazy<PrinterManager> instance = 
            new Lazy<PrinterManager>(() => new PrinterManager());

        private static ILogger logger = new Logger("log.txt");

        private PrinterManager()
        {
            Printers = new List<Printer>();
        }

        public static PrinterManager Instance => instance.Value;

        public static ILogger Logger
        {
            get => logger;
            set
            {
                if (logger == null)
                {
                    throw new ArgumentNullException($"Argument {nameof(logger)} is null");
                }

                logger = value;
            }
        }

        public static List<Printer> Printers { get; set; }

        public static bool Add(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"Argument {nameof(printer)} is null");
            }

            if (!Printers.Contains(printer))
            {
                Printers.Add(printer);
                return true;
            }

            return false;
        }

        public static void Print(Printer printer, string path)
        {
            Logger.Log("Print started");

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.ShowDialog();

                using (var file = File.OpenRead(openFileDialog.FileName))
                {
                    if (!Printers.Contains(printer))
                    {
                        throw new InvalidOperationException($"Printer {printer} not found");
                    }

                    printer.Print(file);
                }
            }

            Logger.Log("Print finished");
        }
    }
}

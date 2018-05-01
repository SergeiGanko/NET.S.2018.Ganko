using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    internal static class PrinterManager
    {
        static PrinterManager()
        {
            Printers = new List<Printer>();
        }

        public static ILogger Logger { get; set; } = new Logger("log.txt");

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

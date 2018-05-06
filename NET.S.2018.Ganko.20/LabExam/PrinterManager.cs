using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Class PrinterManager is a Singleton
    /// </summary>
    internal sealed class PrinterManager
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static readonly Lazy<PrinterManager> instance = 
            new Lazy<PrinterManager>(() => new PrinterManager());

        /// <summary>
        /// The printers collection
        /// </summary>
        private readonly List<Printer> printers;

        /// <summary>
        /// The logger
        /// </summary>
        private ILogger logger = new Logger("log.txt");

        /// <summary>
        /// Prevents a default instance of the <see cref="PrinterManager"/> class from being created.
        /// </summary>
        private PrinterManager()
        {
            printers = new List<Printer>();
        }

        /// <summary>
        /// Gets the instance of the class.
        /// </summary>
        public static PrinterManager Instance => instance.Value;

        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when the logger is null</exception>
        public ILogger Logger
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

        /// <summary>
        /// Gets the printers.
        /// </summary>
        public IReadOnlyCollection<Printer> Printers => printers.AsReadOnly();

        /// <summary>
        /// Adds the specified printer to the coolection of printers.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <exception cref="ArgumentNullException">Throws when printer is null</exception>
        /// <exception cref="InvalidOperationException">Throws when the printer is already exists in the collection of printers</exception>
        public void Add(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"Argument {nameof(printer)} is null");
            }

            if (printers.Contains(printer))
            {
                throw new InvalidOperationException($"Printer {printer} is already exists");
            }

            printer.PrintStart += (sender, args) => Logger.Log($"Printing started. Printer: {args.Printer}\n");
            printer.PrintEnd += (sender, args) => Logger.Log($"Printing ended. Printer: {args.Printer}\n");
            printers.Add(printer);
            Logger.Log($"Printer {printer} successfully added to the printer manager\n");
        }

        /// <summary>
        /// Prints on the specified printer.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <exception cref="ArgumentNullException">fileName</exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Print(Printer printer, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException($"Argument {nameof(fileName)} is null, empty or whitespace");
            }

            if (!printers.Contains(printer))
            {
                throw new InvalidOperationException($"Printer {printer} not found");
            }

            using (var file = File.OpenRead(fileName))
            {
                printer.Print(file);
            }
        }
    }
}

using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Class represents all Epson printers
    /// </summary>
    /// <seealso cref="LabExam.Printer" />
    public sealed class EpsonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpsonPrinter"/> class.
        /// </summary>
        /// <param name="model">The model of the printer.</param>
        public EpsonPrinter(string model) : base(model)
        {
            Name = "Epson";
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Emulates printing on Epson printer.
        /// </summary>
        /// <param name="stream">The stream.</param>
        protected override void EmulatePrint(Stream stream)
        {
            Console.WriteLine($"Epson printing...");
            for (int i = 0; i < stream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(stream.ReadByte());
            }

            Console.ReadKey();
        }
    }
}

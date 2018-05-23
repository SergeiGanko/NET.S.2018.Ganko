using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Class represents all Canon printers
    /// </summary>
    public sealed class CanonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        /// <param name="model">The model of the printer.</param>
        public CanonPrinter(string model) : base(model)
        {
            Name = "Canon";
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Emulates printing on Canon printer.
        /// </summary>
        /// <param name="stream">The stream.</param>
        protected override void EmulatePrint(Stream stream)
        {
            Console.WriteLine($"Canon printing...");
            for (int i = 0; i < stream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}

using System;

namespace LabExam
{
    /// <summary>
    /// Class PrinterFactory
    /// </summary>
    public static class PrinterFactory
    {
        /// <summary>
        /// Creates the instance of the concrete printer.
        /// </summary>
        /// <param name="name">The name of the printer.</param>
        /// <param name="model">The model of the printer.</param>
        /// <returns>Returns instance of CanonPrinter or EpsonPrinter</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Printer CreatePrinter(string name, string model)
        {
            switch (name)
            {
                case "Canon":
                    return new CanonPrinter(model);

                case "Epson":
                    return new EpsonPrinter(model);

                default: throw new ArgumentException($"There is no printer with such name");
            }
        }
    }
}

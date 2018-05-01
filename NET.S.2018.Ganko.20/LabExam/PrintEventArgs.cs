using System;

namespace LabExam
{
    public class PrintEventArgs : EventArgs
    {
        public PrintEventArgs(Printer printer, string message)
        {
            this.Printer = printer ?? throw new ArgumentNullException($"Argument {nameof(printer)} is null");

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException($"Argument {nameof(message)} is null or empty string");
            }

            this.Message = message;
        }

        public Printer Printer { get; }

        public string Message { get; }
    }
}

using System;

namespace LabExam
{
    /// <summary>
    /// The class stores information, which is sent to the recipients of the event notification.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class PrintEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintEventArgs"/> class.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">Throws when one of the arguments is null
        /// </exception>
        public PrintEventArgs(Printer printer, string message)
        {
            this.Printer = printer ?? throw new ArgumentNullException($"Argument {nameof(printer)} is null");

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException($"Argument {nameof(message)} is null or empty string");
            }

            this.Message = message;
        }

        /// <summary>
        /// Gets the printer.
        /// </summary>
        public Printer Printer { get; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get; }
    }
}

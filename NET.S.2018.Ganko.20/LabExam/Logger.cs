using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Class Logger
    /// </summary>
    /// <seealso cref="LabExam.ILogger" />
    public sealed class Logger : ILogger
    {
        /// <summary>
        /// The path of log file
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">Throws when path is null, empty or whitespace string</exception>
        public Logger(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"Argument {nameof(path)} is null, empty or whitespace");
            }

            this.path = path;
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Log(string message)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            using (var stream = new FileStream(this.path, FileMode.Append))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(message);
                }
            }
        }
    }
}

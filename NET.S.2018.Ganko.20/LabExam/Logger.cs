using System;
using System.IO;

namespace LabExam
{
    public class Logger : ILogger
    {
        private readonly string path;

        public Logger(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"Argument {nameof(path)} is null, empty or whitespace");
            }

            this.path = path;
        }

        public void Log(string message)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            using (var file = File.AppendText(path))
            {
                file.Write(message);
            }
        }
    }
}

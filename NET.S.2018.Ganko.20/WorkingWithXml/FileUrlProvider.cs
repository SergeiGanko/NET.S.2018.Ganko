using System;
using System.Collections.Generic;
using System.IO;
using WorkingWithXml.Interfaces;

namespace WorkingWithXml
{
    public sealed class FileUrlProvider : IFileUrlProvider
    {
        private readonly string path;

        public FileUrlProvider(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"Argument {nameof(path)} is null or empty");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File {path} not found");
            }

            this.path = path;
        }

        public IEnumerable<string> GetAllUrls()
        {
            using (var fileStream = File.OpenRead(this.path))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        yield return reader.ReadLine();
                    }
                }
            }
        }
    }
}

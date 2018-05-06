using System;
using System.Collections.Generic;
using System.IO;
using WorkingWithXml.Interfaces;

namespace WorkingWithXml
{
    /// <summary>
    /// Provides text data from file to string 
    /// </summary>
    public sealed class UriStringProvider : IDataProvider<string>
    {
        /// <summary>
        /// The data file path
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="UriStringProvider"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">Throw when path is null or empty</exception>
        /// <exception cref="FileNotFoundException">Throws when file not found</exception>
        public UriStringProvider(string path)
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

        /// <summary>
        /// Gets all data from file.
        /// </summary>
        /// <returns>
        /// Returns sequence with data
        /// </returns>
        public IEnumerable<string> GetAllData()
        {
            var result = new List<string>();

            using (var fileStream = File.OpenRead(this.path))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    var line = String.Empty;

                    while ((line = reader.ReadLine()) != null)
                    {
                        result.Add(line);
                    }
                }
            }

            return result;
        }
    }
}

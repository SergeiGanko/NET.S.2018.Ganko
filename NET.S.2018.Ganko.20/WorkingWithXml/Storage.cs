using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithXml.Entities;
using WorkingWithXml.Interfaces;
using System.Xml.Linq;

namespace WorkingWithXml
{
    /// <summary>
    /// Storage class
    /// </summary>
    public sealed class Storage : IStorage<UrlAddress>
    {
        /// <summary>
        /// The xml file path
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Storage"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">Throws when path is null or empty</exception>
        public Storage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"Argument {nameof(path)} is null or empty");
            }

            this.path = path;
        }

        /// <summary>
        /// Stores the specified urls to xml file.
        /// </summary>
        /// <param name="urls">The urls.</param>
        public void Store(IEnumerable<UrlAddress> urls)
        {
            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-16", null),
                new XElement(
                    "urlAdresses",
                    urls.Select(uri =>
                        new XElement(
                            "urlAddress",
                            new XElement("host", 
                                new XAttribute("name", uri.Host)),
                            new XElement("uri", uri.Segments?.Select(segment => 
                                new XElement("segment", segment))),
                            new XElement("parameters", uri.Parameters?.Select(pair =>
                                new XElement("parameter", 
                                    new XAttribute("value", pair.Value), 
                                    new XAttribute("key", pair.Key))))))));

            document.Descendants().Where(e => e.Name == "parameters" && !e.HasElements);

            document.Save(path);
        }
    }
}

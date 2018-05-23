using System.Collections.Generic;

namespace WorkingWithXml.Entities
{
    /// <summary>
    /// UrlAddress class
    /// </summary>
    public sealed class UrlAddress
    {
        /// <summary>
        /// Gets or sets the scheme.
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the segments.
        /// </summary>
        public List<string> Segments { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public List<KeyValuePair<string, string>> Parameters { get; set; } 
            = new List<KeyValuePair<string, string>>();
    }
}

using System;
using System.Collections.Generic;

namespace WorkingWithXml.Entities
{
    [Serializable]
    public sealed class UrlAddress
    {
        public string OriginalString { get; set; }

        public string Scheme { get; set; }

        public string Host { get; set; }

        public List<string> Segments { get; set; }

        public List<KeyValuePair<string, string>> Parameters { get; set; }
    }
}

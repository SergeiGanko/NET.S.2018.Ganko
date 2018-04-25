using System;
using System.Collections.Generic;

namespace Task5.Solution
{
    public class Document
    {
        private List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }

        public IEnumerable<DocumentPart> Parts
        {
            get
            {
                foreach (var part in parts)
                {
                    yield return part;
                }
            }
        }
    }
}

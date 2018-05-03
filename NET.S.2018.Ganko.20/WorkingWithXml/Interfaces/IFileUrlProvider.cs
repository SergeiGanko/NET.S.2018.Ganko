using System.Collections.Generic;

namespace WorkingWithXml.Interfaces
{
    public interface IFileUrlProvider
    {
        IEnumerable<string> GetAllUrls();
    }
}
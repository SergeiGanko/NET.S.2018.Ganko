using WorkingWithXml;
using WorkingWithXml.Entities;
using WorkingWithXml.Logger;

namespace WorkinWithXmlCUI
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            string dataFilePath = "data.txt";
            string logFilePath = "log.txt";
            string xmlFilePath = "result.xml";

            var urlService = new Service<string, UrlAddress>(
                new UriStringProvider(dataFilePath),
                new Mapper<string, UrlAddress>(new Parser(), new Logger(logFilePath)),
                new Storage(xmlFilePath));

            urlService.Export();
        }
    }
}

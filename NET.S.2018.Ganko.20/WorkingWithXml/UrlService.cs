using System.Linq;
using System.Xml.Linq;
using WorkingWithXml.Interfaces;

namespace WorkingWithXml
{
    public sealed class UrlService
    {
        private readonly IUrlAdressParser urlAdressParser;

        private readonly IUrlConverterToXml urlConverterToXml;

        private readonly IFileUrlProvider fileUrlProvider;

        public UrlService(IUrlAdressParser urlAdressParser,
                          IUrlConverterToXml urlConverterToXml,
                          IFileUrlProvider fileUrlProvider)
        {
            this.urlAdressParser = urlAdressParser;
            this.urlConverterToXml = urlConverterToXml;
            this.fileUrlProvider = fileUrlProvider;
        }

        public void Convert()
        {
            var urls = fileUrlProvider.GetAllUrls();

            var parsedUrls = urls.Select(u =>
                    {
                        var result = urlAdressParser.Parse(u);

                        if (result == null)
                        {
                            //logger.Log(u)
                        }

                        return result;
                    });

            var doc = new XDocument();
            var root = new XElement("urlAdresses");
            doc.Add(root);

            foreach (var url in parsedUrls)
            {
                var convertedUrl = urlConverterToXml.ExportToXml(url);

                root.Add(convertedUrl);
            }
        }
    }
}

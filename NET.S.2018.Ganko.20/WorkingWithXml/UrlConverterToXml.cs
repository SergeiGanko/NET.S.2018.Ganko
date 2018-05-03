using System.Linq;
using System.Xml.Linq;
using WorkingWithXml.Entities;
using WorkingWithXml.Interfaces;

namespace WorkingWithXml
{
    public sealed class UrlConverterToXml : IUrlConverterToXml
    {
        public XElement ExportToXml(UrlAddress urlAddress)
        {
            var xmlUrl = new XElement("urlAddress",
                new XElement("host", new XAttribute("name", urlAddress.Host)),
                new XElement("uri", urlAddress.Segments.Select(
                    (s) => new XElement("segment", s))),
                new XElement("parameters", urlAddress.Parameters.Select(
                    (kv) => new XElement("parameter", new XAttribute("key", kv.Key), new XAttribute("value", kv.Value)))));

            return xmlUrl;
        }
    }
}

using System.Xml.Linq;
using WorkingWithXml.Entities;

namespace WorkingWithXml.Interfaces
{
    public interface IUrlConverterToXml
    {
        XElement ExportToXml(UrlAddress urlAddress);
    }
}
using WorkingWithXml.Entities;

namespace WorkingWithXml.Interfaces
{
    public interface IUrlAdressParser
    {
        UrlAddress Parse(string url);
    }
}
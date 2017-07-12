using System;
using System.Xml.Linq;

namespace Infrastructure.Interfacies.DTO
{
    public class XmlDTO
    {
        public Guid Id { get; set; }
        public XDocument Document { get; set; }
    }
}
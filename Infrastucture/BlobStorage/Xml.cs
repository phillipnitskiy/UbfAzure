using System;
using System.Xml.Linq;

namespace Infrastucture.BlobStorage
{
    public class Xml
    {
        public Guid Id { get; set; }
        public XDocument Document { get; set; }
    }
}
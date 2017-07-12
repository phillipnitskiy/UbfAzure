using System;
using Infrastructure.Interfacies.DTO;

namespace Infrastructure.Interfacies.Interfacies
{
    public interface IXmlRepository : IRepository<XmlDTO, Guid>
    {
        
    }
}
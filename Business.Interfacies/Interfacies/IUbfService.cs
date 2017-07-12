using System;
using System.Xml.Linq;

namespace Business.Interfacies.Interfacies
{
    public interface IUbfService
    {
        Guid ValidateUbf(int producerId, XDocument xml);
        XDocument GetValidatedUbf(int producerId, Guid id);
        int GetStatus(int producerId, Guid id);
    }
}
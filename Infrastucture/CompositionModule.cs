using System;
using Infrastructure.Interfacies.Interfacies;
using Infrastucture.BlobStorage;
using Infrastucture.QueueStorage;
using Infrastucture.SQLAzure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Practices.Unity;

namespace Infrastucture
{
    public class CompositionModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<DbContext, GDV_POCContext>();

            Container.RegisterType<IUbfRepository, UbfRepository>();
            Container.RegisterType<IXmlRepository, XmlRepository>();
            Container.RegisterType<IMessageRepository<Guid>, MessageRepository>();
        }
    }
}

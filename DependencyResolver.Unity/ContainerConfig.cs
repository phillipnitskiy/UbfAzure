using System;
using Business.Interfacies.Interfacies;
using Business.Servicies;
using Infrastructure.Interfacies.Interfacies;
using Infrastucture.BlobStorage;
using Infrastucture.QueueStorage;
using Infrastucture.SQLAzure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Practices.Unity;

namespace DependencyResolver.Unity
{
    public static class ContainerConfig
    {

        public static void ConfigureContainer(this IUnityContainer container)
        {
            container.RegisterType<DbContext, GDV_POCContext>();

            container.RegisterType<IUbfRepository, UbfRepository>();
            container.RegisterType<IXmlRepository, XmlRepository>();
            container.RegisterType<IMessageRepository<Guid>, MessageRepository>();

            container.RegisterType<IUbfService, UbfService>();
        }

    }
}

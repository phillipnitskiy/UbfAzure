using System;
using Business.Interfacies.Interfacies;
using Business.Servicies;
using Infrastructure.Interfacies.DTO;
using Infrastructure.Interfacies.Interfacies;
using Infrastucture.BlobStorage;
using Ninject;
using Infrastucture.SQLAzure;
using Ninject.Web.Common;
using Microsoft.EntityFrameworkCore;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }
        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<DbContext>().To<GDV_POCContext>().InRequestScope();
            }
            else
            {

            }

            kernel.Bind<IUbfRepository>().To<UbfRepository>();
            kernel.Bind<IXmlRepository>().To<XmlRepository>();

            kernel.Bind<IUbfService>().To<UbfService>();
        }
    }
}

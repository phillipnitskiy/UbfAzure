using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfacies.Interfacies;
using Business.Servicies;
using Infrastructure.Interfacies.DTO;
using Infrastructure.Interfacies.Interfacies;
using Ninject;
using Infrastucture.Models;
using Infrastucture.Repositories;
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

            kernel.Bind<IRepository<UbfDTO, Guid>>().To<UbfRepository>();

            kernel.Bind<IUbfService>().To<UbfService>();
        }
    }
}

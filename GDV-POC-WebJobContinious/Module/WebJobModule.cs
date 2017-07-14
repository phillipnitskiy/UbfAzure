using Infrastructure.Interfacies.Interfacies;
using Infrastucture.SQLAzure;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;

namespace GDV_POC_WebJobContinious.Module
{
    public class WebJobModule : NinjectModule
    {
        public override void Load()
        {
            Kernel?.Bind<DbContext>().To<GDV_POCContext>();
            Kernel?.Bind<IUbfRepository>().To<UbfRepository>();
        }
    }
}
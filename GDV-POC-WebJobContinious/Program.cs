using System.Configuration;
using GDV_POC_WebJobContinious.Activator;
using GDV_POC_WebJobContinious.Module;
using Infrastructure.Interfacies.Interfacies;
using Microsoft.Azure.WebJobs;
using Ninject;

namespace GDV_POC_WebJobContinious
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var storageConn = ConfigurationManager
                .ConnectionStrings["AzureWebJobsStorage"].ConnectionString;

            var dashboardConn = ConfigurationManager
                .ConnectionStrings["AzureWebJobsDashboard"].ConnectionString;

            var kernel = CreateKernel();

            JobHostConfiguration config = new JobHostConfiguration
            {
                StorageConnectionString = storageConn,
                DashboardConnectionString = dashboardConn,
                JobActivator = new NinjectActivator(kernel)
            };

            Functions._ubfRepository = kernel.Get<IUbfRepository>();

            JobHost host = new JobHost(config);
            host.RunAndBlock();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new WebJobModule());
            return kernel;
        }
    }
}

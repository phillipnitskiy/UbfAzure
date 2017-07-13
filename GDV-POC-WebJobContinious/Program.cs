using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

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

            JobHostConfiguration config = new JobHostConfiguration
            {
                StorageConnectionString = storageConn,
                DashboardConnectionString = dashboardConn
            };

            JobHost host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}

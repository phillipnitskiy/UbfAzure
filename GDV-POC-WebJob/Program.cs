using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace GDV_POC_WebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            //var config = new JobHostConfiguration();
            //
            //if (config.IsDevelopment)
            //{
            //    config.UseDevelopmentSettings();
            //}

            var _storageConn = ConfigurationManager
                .ConnectionStrings["AzureWebJobsStorage"].ConnectionString;

            var _dashboardConn = ConfigurationManager
                .ConnectionStrings["AzureWebJobsDashboard"].ConnectionString;
            
            JobHostConfiguration config = new JobHostConfiguration();
            config.StorageConnectionString = _storageConn;
            config.DashboardConnectionString = _dashboardConn;
            
            JobHost host = new JobHost(config);
            host.RunAndBlock();
            //var host = new JobHost();
            // The following code will invoke a function called ManualTrigger and 
            // pass in data (value in this case) to the function
            //host.Call(typeof(Functions).GetMethod("ManualTrigger"), new { value = 20 });
        }
    }
}

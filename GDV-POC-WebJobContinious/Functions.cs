using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Azure.WebJobs;

namespace GDV_POC_WebJobContinious
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("ubf-queue")] string message,
            [Blob("ubf-original/{queueTrigger}")] string input,
            [Blob("ubf-validated/{queueTrigger}")] out string output,
            TextWriter log)
        {
            XDocument xDoc = XDocument.Parse(input);

            int producerId = int.Parse(xDoc.Descendants("PayloadId").First().Value);
            if (producerId == 2)
            {
                XElement errorXElement = new XElement("ERROR.MSG", "EXPECTED 1");
                xDoc.Root?.Add(errorXElement);
            }

            output = xDoc.ToString();
        }
    }
}

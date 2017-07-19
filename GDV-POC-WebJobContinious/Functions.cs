using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Infrastructure.Interfacies.Interfacies;
using Microsoft.Azure.WebJobs;
using Ninject;

namespace GDV_POC_WebJobContinious
{
    public class Functions
    {
        [Inject]
        public static IUbfRepository _ubfRepository { get; set; }

        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("ubf-queue")] string message,
            [Blob("ubf-original/{queueTrigger}")] string input,
            [Blob("ubf-validated/{queueTrigger}")] out string output,
            TextWriter log)
        {
            var e = _ubfRepository.GetByKey(Guid.Parse(message));

            XDocument xDoc = XDocument.Parse(input);
            int payloadId = int.Parse(xDoc.Descendants("PayloadId").First().Value);
            if (payloadId == 1)
            {
                e.Status = 0;
            }
            else if (payloadId == 2)
            {
                XElement errorXElement = new XElement("ERROR.MSG", "EXPECTED 1");
                xDoc.Root?.Add(errorXElement);

                e.Status = 2;
            }
            else
            {
                e.Status = 2;
            }

            output = xDoc.ToString();

            _ubfRepository.Update(e);
        }
    }

}

using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Infrastucture.QueueStorage
{
    public class QueueStorageHelper
    {
        public static CloudQueue GetQueue(string storageConnectionString, string queueName)
        {
            // Create blob client and return reference to the container
            var queueStorageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var queueClient = queueStorageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);

            // Create the queue if it doesn't already exist.
            queue.CreateIfNotExists();

            return queue;
        }

        public static CloudQueue GetQueueFromConfiguration(string connectionStringKey,
            string queueNameKey)
        {
            // Pull these from config
            var storageConnectionString = ConfigurationManager.AppSettings[connectionStringKey];
            var queueName = ConfigurationManager.AppSettings[queueNameKey];

            return GetQueue(storageConnectionString, queueName);
        }

        public static CloudQueue GetQueueFromConfiguration(string queueNameKey)
        {
            return GetQueueFromConfiguration("StorageConnectionString", queueNameKey);
        }
    }
}
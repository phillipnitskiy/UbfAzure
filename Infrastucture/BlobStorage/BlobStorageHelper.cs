using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Infrastucture.BlobStorage
{
    public static class BlobStorageHelper
    {
        public static CloudBlobContainer GetBlobContainer(string connectionString, string containerName)
        {
            // Create blob client and return reference to the container
            var blobStorageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = blobStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            return container;
        }

        public static CloudBlobContainer GetBlobContainerFromConfiguration(string connectionStringKey,
            string containerNameKey)
        {
            // Pull these from config
            var blobStorageConnectionString = ConfigurationManager.AppSettings[connectionStringKey];
            var blobStorageContainerName = ConfigurationManager.AppSettings[containerNameKey];

            return GetBlobContainer(blobStorageConnectionString, blobStorageContainerName);
        }

        public static CloudBlobContainer GetBlobContainerFromConfiguration(string containerNameKey)
        {
            return GetBlobContainerFromConfiguration("BlobStorageConnectionString", containerNameKey);
        }
    }
}
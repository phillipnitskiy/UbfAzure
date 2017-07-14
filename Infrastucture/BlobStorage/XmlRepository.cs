using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Infrastructure.Interfacies.DTO;
using Infrastructure.Interfacies.Interfacies;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Infrastucture.BlobStorage
{
    public class XmlRepository : IXmlRepository
    {
        public string ContainerConnectionStringName { get; set; }

        public XmlDTO GetByKey(Guid key)
        {
            var container = BlobStorageHelper.GetBlobContainerFromConfiguration(ContainerConnectionStringName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(key.ToString());

            string xml = blockBlob.DownloadText();

            // strange character appears at the start of xml string
            int startIndex = xml.IndexOf('<');
            if (startIndex > 0)
            {
                xml = xml.Remove(0, startIndex);
            }

            var xDoc = XDocument.Parse(xml);
            return new XmlDTO {Id = key, Document = xDoc};
        }

        public IQueryable<XmlDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guid Create(XmlDTO entity)
        {
            var container = BlobStorageHelper.GetBlobContainerFromConfiguration(ContainerConnectionStringName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(entity.Id.ToString());

            blockBlob.UploadText(entity.Document.ToString());

            return entity.Id;
        }

        public void Delete(XmlDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(XmlDTO entity)
        {
            Create(entity);
        }
    }
}
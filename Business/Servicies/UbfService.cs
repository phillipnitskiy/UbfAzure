using System;
using System.Xml.Linq;
using System.Xml.Schema;
using Business.Interfacies.Exceptions;
using Business.Interfacies.Interfacies;
using Business.Validator;
using Infrastructure.Interfacies.DTO;
using Infrastructure.Interfacies.Interfacies;

namespace Business.Servicies
{
    public class UbfService : IUbfService
    {
        private readonly IUbfRepository _ubfRepository;
        private readonly IXmlRepository _xmlRepository;
        private readonly IMessageRepository<Guid> _messageRepository;

        public UbfService(IUbfRepository ubfRepository, IXmlRepository xmlRepository, IMessageRepository<Guid> messageRepository)
        {
            _ubfRepository = ubfRepository;
            _xmlRepository = xmlRepository;
            _messageRepository = messageRepository;
        }

        public Guid ValidateUbf(int producerId, XDocument xml)
        {
            xml.ValidateXmlScheme();
            
            var guid =_ubfRepository.Create(new UbfDTO {ProducerId = producerId, Status = 1});

            _xmlRepository.ContainerConnectionStringName = "BlobStorageContainerNameOriginal";
            _xmlRepository.Create(new XmlDTO {Id = guid, Document = xml});

            _messageRepository.Add(guid);

            return guid;
        }

        public XDocument GetValidatedUbf(int producerId, Guid id)
        {
            var ubf = _ubfRepository.GetByKey(id);

            if (ubf == null)
            {
                throw new ItemNotFoundException();
            }
            if (producerId != ubf.ProducerId)
            {
                throw new AccessDeniedException();
            }

            _xmlRepository.ContainerConnectionStringName = "BlobStorageContainerNameValidated";
            var xmlDto = _xmlRepository.GetByKey(id);

            if (xmlDto == null)
            {
                throw new ItemNotFoundException();
            }

            return xmlDto.Document;
        }

        public int GetStatus(int producerId, Guid id)
        {
            var ubf = _ubfRepository.GetByKey(id);

            if (ubf == null)
            {
                throw new ItemNotFoundException();
            }
            if (producerId != ubf.ProducerId)
            {
                throw new AccessDeniedException();
            }

            return ubf.Status;
        }
    }
}
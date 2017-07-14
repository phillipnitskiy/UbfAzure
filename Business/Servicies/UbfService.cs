﻿using System;
using System.Xml.Linq;
using Business.Interfacies.Interfacies;
using Infrastructure.Interfacies.DTO;
using Infrastructure.Interfacies.Interfacies;

namespace Business.Servicies
{
    public class UbfService : IUbfService
    {
        private readonly IUbfRepository _ubfRepository;
        private readonly IXmlRepository _xmlRepository;
        private readonly IMessageRepository<Guid> _messageRepository;

        private static readonly string xsdMarkup =
  @"<?xml version='1.0'?>
                                    <xsd:schema xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
	                                    <xsd:element name='ubf'>
		                                    <xsd:complexType>  
			                                    <xsd:sequence>  
				                                    <xsd:element name='PayloadId' type='xsd:string'/>    
			                                    </xsd:sequence>  
		                                    </xsd:complexType>  
	                                    </xsd:element>
                                    </xsd:schema>";

        public UbfService(IUbfRepository ubfRepository, IXmlRepository xmlRepository, IMessageRepository<Guid> messageRepository)
        {
            _ubfRepository = ubfRepository;
            _xmlRepository = xmlRepository;
            _messageRepository = messageRepository;
        }

        public Guid ValidateUbf(int producerId, XDocument xml)
        {
            //XmlSchemaSet schemas = new XmlSchemaSet();
            //schemas.Add("", XmlReader.Create(new StringReader(xsdMarkup)));

            //xml.Validate(schemas, null);
            //var guid = Guid.NewGuid();

            // TODO: later tis will validate xml scheme and throw an exception if invalid

            var guid =_ubfRepository.Create(new UbfDTO {ProducerId = producerId, Status = 1});

            _xmlRepository.ContainerConnectionStringName = "BlobStorageContainerNameOriginal";
            _xmlRepository.Create(new XmlDTO {Id = guid, Document = xml});

            _messageRepository.Add(guid);

            return guid;
        }

        public XDocument GetValidatedUbf(int producerId, Guid id)
        {
            var ubf = _ubfRepository.GetByKey(id);

            if (ubf.ProducerId == producerId)
            {
                _xmlRepository.ContainerConnectionStringName = "BlobStorageContainerNameValidated";
                var xmlDto = _xmlRepository.GetByKey(id);
                return xmlDto.Document;
            }

            // TODO: later tis will throw exception
            
            return null;
        }

        public int GetStatus(int producerId, Guid id)
        {
            var ubfStatus = _ubfRepository.GetByKey(id);
            return ubfStatus.Status;
        }
    }
}
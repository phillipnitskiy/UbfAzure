using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Business.Interfacies.Exceptions;

namespace Business.Validator
{
    public class XmlValidator
    {
        private static readonly string XsdMarkup =
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

        private readonly XmlSchemaSet _schemaSet;
        public XmlValidator()
        {
            _schemaSet = new XmlSchemaSet();
            _schemaSet.Add("", XmlReader.Create(new StringReader(XsdMarkup)));
        }

        public void ValidateXmlScheme(XDocument xml)
        {
            try
            {
                xml.Validate(_schemaSet, null);
            }
            catch (XmlSchemaValidationException e)
            {
                throw new XmlValidationException("Xml scheme validation error.", e);
            }
        }
    }
}
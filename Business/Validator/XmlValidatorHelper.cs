using System.Xml.Linq;

namespace Business.Validator
{
    public static class XmlValidatorHelper
    {
        public static void ValidateXmlScheme(this XDocument xml)
        {
            var validator = new XmlValidator();
            validator.ValidateXmlScheme(xml);
        }
    }
}
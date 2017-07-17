using System;

namespace Business.Interfacies.Exceptions
{
    public class XmlValidationException : Exception
    {
        public XmlValidationException()
        {

        }

        public XmlValidationException(string message) : base(message)
        {

        }

        public XmlValidationException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
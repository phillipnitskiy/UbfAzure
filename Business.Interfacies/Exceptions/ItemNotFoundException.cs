using System;

namespace Business.Interfacies.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {

        }

        public ItemNotFoundException(string message) : base(message)
        {

        }

        public ItemNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
using System;

namespace Infrastructure.Exceptions
{
    public class ItemExistsException : Exception
    {
        public ItemExistsException(string message) : base(message)
        { }
        
    }
}

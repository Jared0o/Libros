using System;

namespace Infrastructure.Exceptions
{
    public class IsReturnedException : Exception
    {
        public IsReturnedException(string message) : base(message)
        {

        }
    }
}

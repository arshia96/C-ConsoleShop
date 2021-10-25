using System;

namespace Infrastructure.Exceptions
{
    public class InvalidEmptyCartException : Exception
    {
        public InvalidEmptyCartException(string message = "سبد خریدی وجود ندارد") : base(message)
        {
        }
    }
}
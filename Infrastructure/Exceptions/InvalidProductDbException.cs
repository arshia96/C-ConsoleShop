using System;

namespace Infrastructure.Exceptions
{
    public class InvalidProductDbException : Exception
    {
        public InvalidProductDbException(string message = "محصول در دیتابیس نیست") : base(message)
        {
        }
    }
}
using System;

namespace Infrastructure.Exceptions
{
    public class InvalidCartNameException : Exception
    {
        public InvalidCartNameException(string message = "مقدار اسم سبد خرید خالی است") : base(message)
        {
        }
    }
}
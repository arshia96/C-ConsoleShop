using System;

namespace Infrastructure.Exceptions
{
    public class InvalidProductIdException : Exception
    {
        public InvalidProductIdException(string message = "مقدار آیدی محصول اشتباه است") : base(message)
        {
        }
    }
}
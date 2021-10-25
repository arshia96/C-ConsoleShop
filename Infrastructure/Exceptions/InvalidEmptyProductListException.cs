using System;

namespace Infrastructure.Exceptions
{
    public class InvalidEmptyProductListException : Exception
    {
        public InvalidEmptyProductListException(string message = "لیست محصولات خالی است") : base(message)
        {
        }
    }
}
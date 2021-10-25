using System;

namespace Infrastructure.Exceptions
{
    public class InvalidEmptyListException : Exception
    {
        public InvalidEmptyListException(string message = "مقدار لیست خالی است") : base(message)
        {
        }
    }
}
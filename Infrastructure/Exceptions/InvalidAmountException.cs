using System;

namespace Infrastructure.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message = "مقدار مبلغ درست نیست") : base(message)
        {
        }
    }
}
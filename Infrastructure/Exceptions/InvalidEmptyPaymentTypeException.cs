using System;

namespace Infrastructure.Exceptions
{
    public class InvalidEmptyPaymentTypeException : Exception
    {
        public InvalidEmptyPaymentTypeException(string message = "شیوه ی پرداختی برای این سبدخرید تعریف نشده است") : base(message)
        {
        }
    }
}
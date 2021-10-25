using System;

namespace Infrastructure.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string message = "مقادیر وارد شده در اکانت ، معتبر نیست") : base(message)
        {
        }
    }
}
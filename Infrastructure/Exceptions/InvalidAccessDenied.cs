using System;

namespace Infrastructure.Exceptions
{
    public class InvalidAccessDenied : Exception
    {
        public InvalidAccessDenied(string message = "شما دسترسی به این قسمت را ندارید") : base(message)
        {
        }
    }
}
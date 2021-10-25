using System;

namespace Infrastructure.Exceptions
{
    public class InvalidInstallmentMonthsException : Exception
    {
        public InvalidInstallmentMonthsException(string massage = "تعداد ماه اقساط نامعتبر است") : base(massage)
        {
            
        }
    }
}
using Infrastructure.Enums;

namespace ApplicationService.Command
{
    public class PaymentCommand
    {
        /// <summary>
        /// تعداد اقساط
        /// </summary>
        public int InstallmentCount { get; set; }
        /// <summary>
        /// پیش پرداخت
        /// </summary>
        public decimal PrePayment { get; set; }
        /// <summary>
        /// نوع پرداخت
        /// </summary>
        public PaymentMethodType PaymentMethod { get; set; }
    }
}
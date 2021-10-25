using Infrastructure.Enums;

namespace DomainModel
{
    public class PaymentCashMethod : PaymentMethod
    {
        private readonly Cart _cart;
        public override PaymentMethodType PaymentMethodType { get; set; } = PaymentMethodType.CashMethod;
        public PaymentCashMethod(Cart cart)
        {
            _cart = cart;
        }

        public void SetCartPaymentMethodType()
        {
            _cart.PaymentMethodType = PaymentMethodType;
        }
    }
}
using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PaymentCash : Payment
    {
        private readonly Cart _cart;

        /// <summary>
        /// آیدی پرداخت نقدی
        /// </summary>
        private Guid _id { get; }
        /// <summary>
        /// تاریخ معیّن پرداخت نقدی
        /// </summary>
        private DateTime _payTime { get; }
        /// <summary>
        /// مبلغ پرداخت نقدی
        /// </summary>
        public Amount _cash { get; set; }
        public PaymentCash(Amount cash, DateTime payTime, Cart cart)
        {
            _cart = cart;
            _id = Guid.NewGuid();
            _cash = cash;
            _payTime = payTime;
        }
        public override void ResultPayMoney(PaymentStateType paymentState)
        {
            if (paymentState.Equals(PaymentStateType.Success))
            {
                _cart.StateCartType = CartStateType.FullPaidCart;
                throw new Exception("پرداخت با موفقیت انجام شد");
            }
            else
                throw new Exception("پرداخت ناموفق");
        }
    }
}
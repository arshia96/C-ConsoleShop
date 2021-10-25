using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public abstract class Payment
    {
        /// <summary>
        /// آیدی پرداخت
        /// </summary>
        public Guid Id = new Guid();

        /// <summary>
        /// نتیجه ی پرداخت
        /// </summary>
        public abstract void ResultPayMoney(PaymentStateType paymentState);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Enums;

namespace DomainModel
{
    public class PaymentInstallment : Payment
    {
        public PaymentInstallment(Cart cart, PaymentInstallmentMethod installmentMethod)
        {
            _totalCost = installmentMethod.GetAnInstallmentPrice();
            _cart = cart;
            _months = installmentMethod._months;
            PrePayCash = installmentMethod.PrePayCash;
            _commission = installmentMethod._commission;
            Installments = installmentMethod.Installments;
        }
        /// <summary>
        /// کارمزد
        /// </summary>
        private Amount _commission { get; }
        /// <summary>
        /// پیش پرداخت
        /// </summary>
        public Amount PrePayCash { get; }
        /// <summary>
        /// کل مبلغ سبدخرید
        /// </summary>
        private Amount _totalCost { get; }
        /// <summary>
        /// سبد خرید جاری
        /// </summary>
        private Cart _cart { get; }
        /// <summary>
        /// تعداد ماه ها
        /// </summary>
        private int _months { get; }
        /// <summary>
        /// لیست اقساط
        /// </summary>
        public static List<Installment> Installments = new List<Installment>();

        public List<Installment> CreatedInstallments =
            Installments.FindAll(i => i.InstallmentStateType.Equals(InstallmentStateType.CreatedInstallment)).ToList();
        public override void ResultPayMoney (PaymentStateType paymentState)
        {
            var installment = CreatedInstallments.FirstOrDefault();
            if (paymentState.Equals( PaymentStateType.Success))
            {
                _cart.StateCartType = CartStateType.InstallmentCart;
                installment.InstallmentStateType = InstallmentStateType.SuccessInstallment;
                throw new Exception("پرداخت با موفقیت انجام شد");
            }
            installment.InstallmentStateType = InstallmentStateType.FailedInstallment;
            throw new Exception("پرداخت ناموفق");
        }
    }
}
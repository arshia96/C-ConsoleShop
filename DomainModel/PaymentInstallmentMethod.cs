using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Infrastructure.Enums;
using Infrastructure.Exceptions;

namespace DomainModel
{
    public class PaymentInstallmentMethod : PaymentMethod
    {
        public PaymentInstallmentMethod(Cart cart, int months, Amount prePayment)
        {
            _cart = cart;
            _months = months;
            PrePayCash = prePayment;
        }
        public PaymentInstallmentMethod(Cart cart, Amount totalCost, Amount prePayCash, Amount commission, int months)
        {
            _totalCost = totalCost;
            _cart = cart;
            _months = months;
            PrePayCash = prePayCash;
            _commission = commission;
        }
        /// <summary>
        /// کارمزد
        /// </summary>
        public Amount _commission { get; }
        /// <summary>
        /// پیش پرداخت
        /// </summary>
        public Amount PrePayCash { get; }
        /// <summary>
        /// کل مبلغ سبدخرید
        /// </summary>
        public Amount _totalCost { get; }
        /// <summary>
        /// سبد خرید جاری
        /// </summary>
        private Cart _cart { get; }
        /// <summary>
        /// تعداد ماه ها
        /// </summary>
        public int _months { get; }
        /// <summary>
        /// لیست اقساط
        /// </summary>
        public List<Installment> Installments = new List<Installment>();
        /// <summary>
        /// تنظیم نوع پرداخت در سبدخرید
        /// </summary>
        public void SetPaymentMethodType()
        {
            switch (_months)
            {
                case 12:
                    _cart.PaymentMethodType = PaymentMethodType.Installment12Months;
                    break;
                case 24:
                    _cart.PaymentMethodType = PaymentMethodType.Installment12Months;
                    break;
                case 36:
                    _cart.PaymentMethodType = PaymentMethodType.Installment12Months;
                    break;
                default:
                    throw new InvalidInstallmentMonthsException();
            }
        }
        /// <summary>
        /// ساخت اقساط
        /// </summary>
        public void CalculateInstallments()
        {
            int addMonths = -1;
            _totalCost.MinusAmount(_commission);
            _totalCost.DivisionAmount(new Amount(Convert.ToDecimal(_months)));
            var roundedTotalCost = Math.Round(_totalCost.Value);
            for (int i = 1; i <= _months; i++)
            {
                Installment installment = new Installment(_months, new Amount(roundedTotalCost), _commission, 
                    InstallmentStateType.CreatedInstallment, DateTime.Today.AddMonths(addMonths++));
                installment.AddState(new InstallmentStateCreated(installment));
                Installments.Add(installment);
            }
            _cart.AddInstallments(Installments);
        }
        /// <summary>
        /// گرفتن مبلغ یک قسط
        /// </summary>
        public Amount GetAnInstallmentPrice()
        {
            return GetAnInstallmentPrice();
        }
    }
}
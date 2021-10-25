using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid();
        }
        /// <summary>
        /// آیدی سبدخرید
        /// </summary>
        public Guid Id;
        /// <summary>
        /// اسم سبدخرید
        /// </summary>
        public string CartName { get; set; }
        /// <summary>
        /// لیست محصولات داخل سبدخرید
        /// </summary>
        public List<Product> Products = new List<Product>();
        /// <summary>
        /// نوع سبدخرید
        /// </summary>
        public CartStateType StateCartType { get; set; }
        /// <summary>
        /// نوع پرداخت
        /// </summary>
        public PaymentMethodType PaymentMethodType { get; set; }
        /// <summary>
        /// شیوه ی پرداخت شده
        /// </summary>
        public PaymentStateType PaymentStateType { get; set; }
        /// <summary>
        /// شیوه ی پرداخت
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }
        public Payment Payment { get; set; }
        /// <summary>
        /// لیست وضعیت های سبدخرید
        /// </summary>
        private IEnumerable<CartState> _stateHistory = new List<CartState>();
        /// <summary>
        /// لیست اقساط سبدخرید
        /// </summary>
        public List<Installment> Installments = new List<Installment>();
        public void AddInstallments(List<Installment> listInstallments)
        {
            foreach (var installment in listInstallments)
            {
                Installments.Add(installment);
            }
        }
        /// <summary>
        /// اضافه کردن استیت به لیست استیت سبدخرید
        /// </summary>
        public void AddState(CartState cartState)
        {
            var temp = _stateHistory.ToList();
            temp.Add(cartState);
            _stateHistory = temp;
        }
        /// <summary>
        /// ساخت اقساط یا پرداخت نقدی
        /// </summary>
        /// <param name="cart">سبدخرید</param>
        /// <param name="prepayment">پیش پرداخت</param>
        public void CreatePayment(Cart cart, Amount prepayment)
        {
            var cartPrice = cart.Products.Sum(i => i.Price.Value);
            switch (cart.PaymentMethodType)
            {
                case PaymentMethodType.CashMethod:
                    var paymentCashMethod = new PaymentCashMethod(cart);
                    paymentCashMethod.SetCartPaymentMethodType();
                    break;
                case PaymentMethodType.Installment12Months:
                    new PaymentInstallmentMethod(cart, new Amount(cartPrice), prepayment, new Amount(0.12m), 12).CalculateInstallments();
                    break;
                case PaymentMethodType.Installment24Months:
                    new PaymentInstallmentMethod(cart, new Amount(cartPrice), prepayment, new Amount(0.18m), 24).CalculateInstallments();
                    break;
                case PaymentMethodType.Installment36Months:
                    new PaymentInstallmentMethod(cart, new Amount(cartPrice), prepayment, new Amount(0.2m), 36).CalculateInstallments();
                    break;
            }
        }
        public void PaymentStateTypeToPaymentClass(PaymentStateType paymentStateType)
        {
            Payment.ResultPayMoney(paymentStateType);
        }
    }
}
using System.Collections.Generic;
using ApplicationService.Command;
using ApplicationService.Dtos;
using Infrastructure.Enums;

namespace ApplicationService.Interface
{
    public interface IPaymentService
    {
        /// <summary>
        /// تنظیم نوع پرداخت نقدی در سبدخرید
        /// </summary>
        void SetCashPaymentMethodInCart();

        /// <summary>
        /// تنظیم نوع پرداخت اقساط در سبدخرید
        /// </summary>
        /// <param name="prePaymentDecimal">پیش پرداخت</param>
        void SetInstallmentMethodInCart(decimal prePaymentDecimal);

        /// <summary>
        /// نمایش لیست اقساط
        /// </summary>
        List<InstallmentDto> GetInstallmentDtos(CartCommand cartCommand);

        /// <summary>
        /// تنظیم پرداخت در سبدخرید
        /// </summary>
        /// <param name="paymentStateType">نوع پرداخت</param>
        /// <param name="cartCommand">سبدخرید</param>
        /// <param name="cartStateType">وضعیت سبدخرید</param>
        void SetPaymentInCart(PaymentStateType paymentStateType, CartCommand cartCommand);
    }
}
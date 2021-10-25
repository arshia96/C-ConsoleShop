using System;
using System.Collections.Generic;
using ApplicationService.Command;
using ApplicationService.Dtos;
using Infrastructure.Enums;
namespace ApplicationService.Interface
{
    public interface ICartService
    {
        /// <summary>
        /// نمایش محصولات داخل سبدخرید
        /// </summary>
        CartDto ShowCartItem(CartCommand cartCommand);
        /// <summary>
        /// نمایش سبدهای خرید
        /// </summary>
        List<CartDto> ShowCarts();
        /// <summary>
        /// اضافه کردن یک سبدخرید
        /// </summary>
        Guid AddNewCart(AccountCommand accountCommand, string name);
        /// <summary>
        /// حذف یک سبدخرید
        /// </summary>
        void RemoveCart(AccountCommand accountCommand, CartCommand cartCommand);
        /// <summary>
        /// اضافه کردن محصول در سبدخرید دلخواه
        /// </summary>
        void AddProductsToCart(CartCommand cartCommand, List<ProductCommand> productsCommand);
        /// <summary>
        /// حذف محصول در سبدخرید دلخواه
        /// </summary>
        void RemoveProductFromCart(CartCommand cartCommand, ProductCommand productCommand);
        /// <summary>
        /// نهایی کردن سبدخرید
        /// </summary>
        void CheckoutCart(CartCommand cartCommand, PaymentCommand paymentCommand);
        /// <summary>
        /// نمایش مبلغ کل سبدخرید
        /// </summary>
        decimal CartPriceCalculator(CartCommand cartCommand);

        void SetCartState(CartCommand cartCommand);
        /// <summary>
        /// وضعیت سبدخرید
        /// </summary>
        CartDto StateCartType(CartCommand cartCommand);
        /// <summary>
        /// تنظیم وضعیت سبدخرید
        /// </summary>
        void SetStateCartType(CartCommand cartCommand);
        /// <summary>
        /// اولین قسط با وضعیت ساخته شده
        /// </summary>
        InstallmentDto GetFirstCreatedInstallment(CartCommand cartCommand);
        /// <summary>
        /// تنظیم وضعیت قسط
        /// </summary>
        void SetInstallmentState(CartCommand cartCommand, InstallmentCommand installmentCommand, InstallmentStateType installmentStateType);
    }
}
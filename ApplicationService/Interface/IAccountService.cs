using System;
using ApplicationService.Command;
using ApplicationService.Dtos;

namespace ApplicationService.Interface
{
    public interface IAccountService
    { 
        /// <summary>
        /// وارد شدن کاربر
        /// </summary>
        void UserLogin(AccountCommand accountCommand);
        /// <summary>
        /// اضافه کردن سبدخرید در لیست سبدخرید داخل یوزر
        /// </summary>
        void AddCartToCartList(AccountCommand accountCommand, Guid cartId);
        /// <summary>
        /// حذف کردن سبدخرید در لیست سبدخرید در یوزر
        /// </summary>
        void RemoveCartFromCartList(AccountCommand accountCommand, Guid cartId);
        /// <summary>
        /// گرفتن اطلاعات کاربر برای ارسال سبدخرید
        /// </summary>
        AccountDto GetAccountInfo(AccountCommand accountCommand);
    }
}
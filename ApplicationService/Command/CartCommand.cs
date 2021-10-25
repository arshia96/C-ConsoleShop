using System;
using DomainModel;
using Infrastructure.Enums;
using Infrastructure.Exceptions;

namespace ApplicationService.Command
{
    public class CartCommand : CommandBase
    {
        /// <summary>
        /// آیدی سبدخرید
        /// </summary>
        public Guid CartId { get; set; }
        /// <summary>
        /// نام سبدخرید
        /// </summary>
        public string CartName { get; set; }
        /// <summary>
        /// نوع پرداخت سبدخرید
        /// </summary>
        public PaymentMethodType PaymentType { get; set; }
        /// <summary>
        /// نوع سبدخرید
        /// </summary>
        public CartStateType CartStateType { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(CartName))
                throw new InvalidCartNameException();
        }
    }
}
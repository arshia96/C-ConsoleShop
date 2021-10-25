using System.Collections.Generic;
using ApplicationService.Services;
using Infrastructure.Exceptions;

namespace ApplicationService.Command
{
    public class ProductCommand : CommandBase
    {
        /// <summary>
        /// آیدی محصول
        /// </summary>
        public int ProductId { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(ProductId.ToString()))
                throw new InvalidProductIdException();
        }
        /// <summary>
        /// افزودن محصول (محصولات) به سبد خرید
        /// </summary>
        public void AddToProducts(CartCommand cartCommand, ProductCommand productCommand)
        {
            var productCommandList = new List<ProductCommand> {productCommand};
            new CartService().AddProductsToCart(cartCommand, productCommandList);
        }
    }
}
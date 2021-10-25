using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class CartStateInstallmentShipping : CartState
    {
        private readonly Cart _cart;
        public CartStateInstallmentShipping(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.InstallmentCart;
        }
        public override void SetFullPaidState()
        {
            _cart.AddState(new CartStateFullPaid(_cart) { dataTime = DateTime.Now });
        }
    }
}
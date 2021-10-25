using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class CartStateRemovedFromCart : CartState
    {
        private readonly Cart _cart;
        public CartStateRemovedFromCart(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.CartHadRemovedItem;
        }
        public override void SetInstallmentShippingState()
        {
            _cart.AddState(new CartStateInstallmentShipping(_cart) { dataTime = DateTime.Now });
        }
        public override void SetFullPaidState()
        {
            _cart.AddState(new CartStateFullPaid(_cart) { dataTime = DateTime.Now });
        }
    }
}
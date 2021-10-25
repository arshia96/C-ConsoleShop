using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class CartStateCreated : CartState
    {
        private readonly Cart _cart;
        public CartStateCreated(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.CreatedCart;
        }
        public override void SetCreatedState()
        {
            _cart.AddState(new CartStateCreated(_cart) { dataTime = DateTime.Now });
        }
        public override void SetRemovedFromCartState()
        {
            _cart.AddState(new CartStateRemovedFromCart(_cart) {dataTime = DateTime.Now});
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
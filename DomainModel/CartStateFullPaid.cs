using Infrastructure.Enums;

namespace DomainModel
{
    public class CartStateFullPaid : CartState
    {
        private readonly Cart _cart;
        public CartStateFullPaid(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.FullPaidCart;
        }
    }
}
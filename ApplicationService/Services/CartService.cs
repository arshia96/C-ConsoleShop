using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationService.Command;
using ApplicationService.Dtos;
using ApplicationService.Interface;
using DomainModel;
using Infrastructure.Enums;
using Infrastructure.Exceptions;
using DatabaseTable = Repository.Database.DatabaseTable;

namespace ApplicationService.Services
{
    public class CartService : ICartService
    {
        public static readonly DatabaseTable Database = DatabaseTable.GetInstance();
        readonly List<Product> _productsList = Database.ProductsList;
        public CartDto ShowCartItem(CartCommand cartCommand)
        {
            var _cartList = Database.CartList;
            var cart = _cartList.FirstOrDefault(c => c.CartName == cartCommand.CartName);
            var cartDto = new CartDto();
            if (cart != null)
                foreach (var product in cart.Products)
                {
                    var item = new ProductDto()
                    {
                        ProductId = product.ProductId,
                        Name = product.Device.Name,
                        Model = product.Device.Model,
                        Price = product.Price
                    };
                    cartDto.ProductDtos.Add(item);
                }

            return cartDto;
        }
        public List<CartDto> ShowCarts()
        {
            var cartList = Database.CartList;
            var cart = cartList;
            var cartDtos = new List<CartDto>();
            foreach (var c in cart)
            {
                var item = new CartDto() { Name = c.CartName, CartStateType = c.StateCartType };
                cartDtos.Add(item);
            }
            return cartDtos;
        }
        public void SetCartState(CartCommand cartCommand)
        {
            var cartList = Database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id.Equals(cartCommand.CartId));
            if (cart != null) cart.StateCartType = cartCommand.CartStateType;
        }
        public CartDto StateCartType(CartCommand cartCommand)
        {
            var cartList = Database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id.Equals(cartCommand.CartId));
            CartDto cartDto = new CartDto();
            if (cart != null) cartDto.CartStateType = cart.StateCartType;
            return cartDto;
        }

        public void SetStateCartType(CartCommand cartCommand)
        {
            var cartList = Database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id.Equals(cartCommand.CartId));
            if (cart != null) cart.StateCartType = cartCommand.CartStateType;
        }

        public InstallmentDto GetFirstCreatedInstallment(CartCommand cartCommand)
        {
            var cartList = Database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id.Equals(cartCommand.CartId));
            var firstCreatedInstallment = cart.Installments.FirstOrDefault(
                i => i.InstallmentStateType.Equals(InstallmentStateType.CreatedInstallment));
            return new InstallmentDto(firstCreatedInstallment.InstallmentId);
        }
        public void SetInstallmentState(CartCommand cartCommand, InstallmentCommand installmentCommand, InstallmentStateType installmentStateType)
        {
            var cartList = Database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id.Equals(cartCommand.CartId));
            if (cart != null)
            {
                var installment = cart.Installments.SingleOrDefault(i => i.InstallmentId.Equals(installmentCommand.InstallmentId));
                installment.InstallmentStateType = installmentStateType;
            }
        }

        public Guid AddNewCart(AccountCommand accountCommand, string name)
        {
            var cartList = Database.CartList;
            cartList.Add(new Cart() { CartName = name, StateCartType = CartStateType.CreatedCart });
            var cart = cartList.SingleOrDefault(i => i.Id.Equals(cartList.FirstOrDefault(j => j.CartName == name).Id));
            if (cart != null)
            {
                var accountService = new AccountService();
                accountService.AddCartToCartList(accountCommand, cart.Id);
                cart.AddState(new CartStateCreated(cart));
            }
            return cart.Id;
        }
        public void RemoveCart(AccountCommand accountCommand, CartCommand cartCommand)
        {
            var _cartList = Database.CartList;
            var cart = _cartList.FirstOrDefault(i => i.Id.Equals(cartCommand.CartId));
            var cartSelectedIndex = _cartList.FindIndex(i => cart != null && i.Id == cart.Id);
            if (cart != null && (cart.StateCartType.Equals(CartStateType.CreatedCart) ||
                                 cart.StateCartType.Equals(CartStateType.CartHadRemovedItem)))
            {
                _cartList.RemoveAt(cartSelectedIndex);
                new AccountService().RemoveCartFromCartList(accountCommand, cart.Id);
            }
            else
                throw new InvalidAccessDenied();
        }
        public void AddProductsToCart(CartCommand cartCommand, List<ProductCommand> productsCommand)
        {
            var cartList = Database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id == cartCommand.CartId);
            var cartSelected = cartList.SingleOrDefault(i => cart != null && i.Id == cart.Id);
            var products = new List<Product>();
            foreach (var productCommand in productsCommand)
            {
                var product = _productsList.SingleOrDefault(i => i.ProductId == productCommand.ProductId);
                products.Add(product);
            }
            if (cartSelected != null)
                if ((cart.StateCartType.Equals(CartStateType.CreatedCart) ||
                                     cart.StateCartType.Equals(CartStateType.CartHadRemovedItem)))
                {
                    foreach (var product in products)
                        cartSelected.Products.Add(product);
                }
                else
                {
                    var newCart = new Cart { CartName = $"{cartCommand.CartName}" };
                    cartList.Add(newCart);
                    newCart.AddState(new CartStateCreated(newCart));
                    foreach (var product in products)
                    {
                        newCart.Products.Add(product);
                    }
                }
        }

        public void RemoveProductFromCart(CartCommand cartCommand, ProductCommand productCommand)
        {
            var _cartList = Database.CartList;
            var product = _productsList.FirstOrDefault(i => i.ProductId == productCommand.ProductId);
            var cart = _cartList.FirstOrDefault(i => i.Id == cartCommand.CartId);
            if (cart.StateCartType.Equals(CartStateType.CreatedCart) ||
                cart.StateCartType.Equals(CartStateType.CartHadRemovedItem))
            {
                var selectedItemIndex =
                        cart.Products.FindIndex(i => product != null && i.ProductId == product.ProductId);
                _cartList.SingleOrDefault(i => i.Id == cart.Id)?.Products.RemoveAt(selectedItemIndex);
                cart.AddState(new CartStateRemovedFromCart(cart));
            }
            else
                throw new InvalidAccessDenied();
        }
        public decimal CartPriceCalculator(CartCommand cartCommand)
        {
            decimal totalPrices = decimal.Zero;
            var cartList = Database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id == cartCommand.CartId);
            var cartSelected = cartList.SingleOrDefault(i => cart != null && i.Id == cart.Id);
            if (cart != null && (cart.StateCartType.Equals(CartStateType.CreatedCart) ||
                                 cart.StateCartType.Equals(CartStateType.CartHadRemovedItem)))
            {
                if (cartSelected != null)
                    totalPrices = cartSelected.Products.Sum(i => i.Price.Value);
            }
            else
                throw new InvalidAccessDenied();
            return totalPrices;
        }
        public void CheckoutCart(CartCommand cartCommand, PaymentCommand paymentCommand)
        {
            var _cartList = Database.CartList;
            var cart = _cartList.SingleOrDefault(i => i.Id.Equals(cartCommand.CartId));
            if (cart.StateCartType.Equals(CartStateType.CreatedCart) ||
                cart.StateCartType.Equals(CartStateType.CartHadRemovedItem))
            {
                var productsCount = cart.Products.Count;
                if (productsCount > 0)
                {
                    if (cart.PaymentMethodType.Equals(PaymentMethodType.CashMethod))
                    {
                        paymentCommand.PrePayment = CartPriceCalculator(cartCommand);
                        cart.CreatePayment(cart, new Amount(paymentCommand.PrePayment));
                    }
                    else if (cart.PaymentMethodType.Equals(PaymentMethodType.Installment12Months))
                    {
                        cart.CreatePayment(cart, new Amount(paymentCommand.PrePayment));
                    }
                    else if (cart.PaymentMethodType.Equals(PaymentMethodType.Installment24Months))
                    {
                        cart.CreatePayment(cart, new Amount(paymentCommand.PrePayment));
                    }
                    else if (cart.PaymentMethodType.Equals(PaymentMethodType.Installment36Months))
                    {
                        cart.CreatePayment(cart, new Amount(paymentCommand.PrePayment));
                    }
                    else
                    {
                        throw new InvalidEmptyPaymentTypeException();
                    }
                }
                else
                    throw new InvalidEmptyProductListException();
            }
            else
                throw new InvalidAccessDenied();
        }
    }
}
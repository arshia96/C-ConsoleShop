using System.Collections.Generic;
using System.Linq;
using ApplicationService.Command;
using ApplicationService.Dtos;
using ApplicationService.Interface;
using DomainModel;
using Infrastructure.Enums;
using Infrastructure.Exceptions;
using Repository.Database;

namespace ApplicationService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentCommand _paymentCommand;
        private readonly CartCommand _cartCommand;
        private DatabaseTable _databaseTable = DatabaseTable.GetInstance();
        public PaymentService(PaymentCommand paymentCommand, CartCommand cartCommand)
        {
            _paymentCommand = paymentCommand;
            _cartCommand = cartCommand;
        }
        public void SetCashPaymentMethodInCart()
        {
            if (_paymentCommand.PaymentMethod.Equals(PaymentMethodType.CashMethod))
            {
                var cart = _databaseTable.CartList.SingleOrDefault(i => i.Id == _cartCommand.CartId);
                cart.PaymentMethod = new PaymentCashMethod(cart);
            }
        }
        public void SetInstallmentMethodInCart(decimal prePaymentDecimal)
        {
            var prePayment = new Amount(prePaymentDecimal);
            var cart = _databaseTable.CartList.SingleOrDefault(i => i.Id == _cartCommand.CartId);
            switch (_paymentCommand.PaymentMethod)
            {
                case PaymentMethodType.CashMethod:
                    cart.PaymentMethodType = PaymentMethodType.CashMethod;
                    cart.PaymentMethod = new PaymentCashMethod(cart);
                    break;
                case PaymentMethodType.Installment12Months:
                    cart.PaymentMethodType = PaymentMethodType.Installment12Months;
                    cart.PaymentMethod = new PaymentInstallmentMethod(cart, 12, prePayment);
                    break;
                case PaymentMethodType.Installment24Months:
                    cart.PaymentMethodType = PaymentMethodType.Installment24Months;
                    cart.PaymentMethod = new PaymentInstallmentMethod(cart, 24, prePayment);
                    break;
                case PaymentMethodType.Installment36Months:
                    cart.PaymentMethodType = PaymentMethodType.Installment36Months;
                    cart.PaymentMethod = new PaymentInstallmentMethod(cart, 36, prePayment);
                    break;
                default:
                    throw new InvalidEmptyPaymentTypeException();
            }
        }
        public List<InstallmentDto> GetInstallmentDtos(CartCommand cartCommand)
        {
            var _database = DatabaseTable.GetInstance();
            var cart = _database.CartList.SingleOrDefault(c => c.Id == cartCommand.CartId);
            cart.Installments = new DomainService(cart).GetInstallments();
            List<InstallmentDto> installmentDtos = new List<InstallmentDto>();
            foreach (var installment in cart.Installments)
            {
                installmentDtos.Add(new InstallmentDto(installmentCount: installment.InstallmentCount,
                    price: installment.Price.Value, installment.PayDate, installmentStateType: installment.InstallmentStateType));
            }
            return installmentDtos;
        }
        public void SetPaymentInCart(PaymentStateType paymentStateType, CartCommand cartCommand)
        {
            var _database = DatabaseTable.GetInstance();
            var cart = _database.CartList.SingleOrDefault(c => c.Id == cartCommand.CartId);
            cart.PaymentStateType = paymentStateType;
        }
    }
}
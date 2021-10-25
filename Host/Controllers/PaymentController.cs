using System;
using ApplicationService.Command;
using ApplicationService.Interface;
using ApplicationService.Services;
using Infrastructure.Enums;

namespace Host.Controllers
{
    public class PaymentController
    {
        private readonly IAccountService _iAccountService;
        private readonly AccountCommand _accountCommand;
        private readonly CartCommand _cartCommand;
        private readonly ICartService _iCartService;
        private readonly CartController _cartController;
        private readonly IPaymentService _iPaymentService;

        public PaymentController(IAccountService iAccountService, AccountCommand accountCommand, CartCommand cartCommand, ICartService iCartService, CartController cartController,
            IPaymentService iPaymentService)
        {
            _iAccountService = iAccountService;
            _accountCommand = accountCommand;
            _cartCommand = cartCommand;
            _iCartService = iCartService;
            _cartController = cartController;
            _iPaymentService = iPaymentService;
        }
        /// <summary>
        /// گرفتن نوع پرداخت از کاربر
        /// </summary>
        public void GetPaymentType()
        {
            Console.WriteLine("\nWhat PaymentType? 1 - Cash    2 - Installment");
            var enteredMethodNumber = Convert.ToInt32(Console.ReadLine());
            switch (enteredMethodNumber)
            {
                case 1:
                    var cashPaymentMethod = new PaymentCommand() { PaymentMethod = PaymentMethodType.CashMethod };
                    new PaymentService(cashPaymentMethod, _cartCommand).SetCashPaymentMethodInCart();
                    _iCartService.CheckoutCart(_cartCommand, cashPaymentMethod);
                    break;
                case 2:
                    Console.WriteLine(
                        "\n1 - 12 Months + 12% Commission \n2 - 24 Months + 18% Commission \n3 - 36 Months + 24% Commission \n0 - Back");
                    var enteredInstallmentNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nHow Much Money Do You Want Pay For PrePayment?");
                    var enteredPrePayment = Convert.ToDecimal(Console.ReadLine());
                    switch (enteredInstallmentNumber)
                    {
                        case 0:
                            GetPaymentType();
                            break;
                        case 1:
                            _cartCommand.PaymentType = PaymentMethodType.Installment12Months;
                            var paymentMethod12Months = new PaymentCommand()
                            {
                                InstallmentCount = 12,
                                PrePayment = enteredPrePayment,
                                PaymentMethod = PaymentMethodType.Installment12Months
                            };
                            new PaymentService(paymentMethod12Months, _cartCommand).SetInstallmentMethodInCart(enteredPrePayment);
                            _iCartService.CheckoutCart(_cartCommand, paymentMethod12Months);
                            break;
                        case 2:
                            _cartCommand.PaymentType = PaymentMethodType.Installment24Months;
                            var paymentMethod24Months = new PaymentCommand()
                            {
                                InstallmentCount = 24,
                                PrePayment = enteredPrePayment,
                                PaymentMethod = PaymentMethodType.Installment24Months
                            };
                            new PaymentService(paymentMethod24Months, _cartCommand).SetInstallmentMethodInCart(enteredPrePayment);
                            _iCartService.CheckoutCart(_cartCommand, paymentMethod24Months);
                            break;
                        case 3:
                            _cartCommand.PaymentType = PaymentMethodType.Installment36Months;
                            var paymentMethod36Months = new PaymentCommand()
                            {
                                InstallmentCount = 36,
                                PrePayment = enteredPrePayment,
                                PaymentMethod = PaymentMethodType.Installment36Months
                            };
                            new PaymentService(paymentMethod36Months, _cartCommand).SetInstallmentMethodInCart(enteredPrePayment);
                            _iCartService.CheckoutCart(_cartCommand, paymentMethod36Months);
                            break;
                        default:
                            Console.WriteLine("Wrong Number");
                            GetPaymentType();
                            break;
                    }

                    break;
                default:
                    Console.WriteLine("wrong number ... try again ...");
                    GetPaymentType();
                    break;
            }
        }
        /// <summary>
        /// گرفتن نوع پرداخت سبد خرید
        /// </summary>
        public PaymentMethodType GetPaymentMethodType()
        {
            return _cartCommand.PaymentType;
        }
        /// <summary>
        /// پرداخت کردن یا نکردن
        /// </summary>
        public void PayMoneyOrNot(PaymentCommand paymentCommand)
        {
            Console.WriteLine("Do You Want Continue To Pay Money? Y/N");
            var enteredStr = Console.ReadLine()?.ToLower();
            if (!string.IsNullOrEmpty(enteredStr))
            {
                switch (paymentCommand.PaymentMethod)
                {
                    case PaymentMethodType.Installment12Months:
                        switch (enteredStr)
                        {
                            case "y":
                                PayMoney();
                                _iPaymentService.SetPaymentInCart(PaymentStateType.Success, _cartCommand);
                                _iCartService.SetStateCartType(new CartCommand()
                                {
                                    CartStateType = CartStateType.InstallmentCart,
                                    CartId = _cartCommand.CartId
                                });
                                var installment = _iCartService.GetFirstCreatedInstallment(_cartCommand);
                                _iCartService.SetInstallmentState(_cartCommand,new InstallmentCommand(){InstallmentId = installment.InstallmentId},InstallmentStateType.SuccessInstallment);
                                SendCart();
                                break;
                            case "n":
                                _cartController.DisplayCartPanel();
                                break;
                        }
                        break;
                    case PaymentMethodType.Installment24Months:
                        switch (enteredStr)
                        {
                            case "y":
                                PayMoney();
                                _iPaymentService.SetPaymentInCart(PaymentStateType.Success, _cartCommand);
                                _iCartService.SetStateCartType(new CartCommand()
                                {
                                    CartStateType = CartStateType.InstallmentCart,
                                    CartId = _cartCommand.CartId
                                });
                                SendCart();
                                break;
                            case "n":
                                _cartController.DisplayCartPanel();
                                break;
                        }
                        break;
                    case PaymentMethodType.Installment36Months:
                        switch (enteredStr)
                        {
                            case "y":
                                PayMoney();
                                _iPaymentService.SetPaymentInCart(PaymentStateType.Success, _cartCommand);
                                _iCartService.SetStateCartType(new CartCommand()
                                {
                                    CartStateType = CartStateType.InstallmentCart,
                                    CartId = _cartCommand.CartId
                                });
                                SendCart();
                                break;
                            case "n":
                                _cartController.DisplayCartPanel();
                                break;
                        }
                        break;
                    case PaymentMethodType.CashMethod:
                        switch (enteredStr)
                        {
                            case "y":
                                PayMoney();
                                _iPaymentService.SetPaymentInCart(PaymentStateType.Success, _cartCommand);
                                _iCartService.SetStateCartType(new CartCommand()
                                {
                                    CartStateType = CartStateType.FullPaidCart,
                                    CartId = _cartCommand.CartId
                                });
                                SendCart();
                                break;
                            case "n":
                                _cartController.DisplayCartPanel();
                                break;
                        }
                        break;
                    default:
                        throw new Exception("Invalid Entered Letter");
                }
            }
            else
                throw new Exception("Empty Or Null Entered Letter");
        }
        /// <summary>
        /// گرفتن مشخصات کارت بانکی از کاربر
        /// </summary>
        public PaymentStateType PayMoney()
        {
            Console.WriteLine("Please Enter Your 16 Digits CreditCard Number ...");
            var enteredCreditCardNumber = Convert.ToInt64(Console.ReadLine());
            var creditCardNumberLength = Convert.ToInt32(Math.Floor(Math.Log10(enteredCreditCardNumber) + 1));
            if (creditCardNumberLength == 16)
            {
                Console.WriteLine("Enter Your CVV2 ...");
                var enteredCvv2Number = Convert.ToInt32(Console.ReadLine());
                var cvv2NumberLength = Convert.ToInt32(Math.Floor(Math.Log10(enteredCvv2Number) + 1));
                if (cvv2NumberLength >= 3)
                {
                    Console.WriteLine("Completed!");
                    return PaymentStateType.Success;
                }
                Console.WriteLine("Wrong CCV2 Number !! Try Again .....");
                PayMoney();
            }
            else
            {
                Console.WriteLine("Wrong CreditCard Number !! Try Again .....");
                PayMoney();
            }
            return PaymentStateType.Failed;
        }
        /// <summary>
        /// ارسال سبدخرید
        /// </summary>
        public void SendCart()
        {
            var user = _iAccountService.GetAccountInfo(accountCommand: _accountCommand);
            Console.WriteLine("Dear " + user.Name + $" Your Cart With '{_cartCommand.CartName}' Name Will Send In '"
                              + user.Address + "' And We Will Call With This Number '" + user.Phone + "'");
        }
    }
}
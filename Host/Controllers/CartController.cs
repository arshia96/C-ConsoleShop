using System;
using ApplicationService.Command;
using ApplicationService.Interface;
using ApplicationService.Services;
using DomainModel;
using Infrastructure.Enums;
using Infrastructure.Exceptions;

namespace Host.Controllers
{
    public class CartController
    {
        private readonly ICartService _iCartService;
        private readonly IAccountService _iAccountService;
        private readonly AccountCommand _accountCommand;
        private readonly CartCommand _cartCommand;
        private readonly PaymentCommand _paymentCommand;
        private readonly IPaymentService _iPaymentService;
        private readonly ProductCommand _productCommand;
        public CartController(ICartService iCartService, IAccountService iAccountService, AccountCommand accountCommand, ProductCommand productCommand,
            CartCommand cartCommand, PaymentCommand paymentCommand, IPaymentService iPaymentService)
        {
            _iCartService = iCartService;
            _iAccountService = iAccountService;
            _accountCommand = accountCommand;
            _productCommand = productCommand;
            _cartCommand = cartCommand;
            _paymentCommand = paymentCommand;
            _iPaymentService = iPaymentService;
        }
        public string GetCartName()
        {
            Console.WriteLine("Enter Your Cart Name ...");
            var cartName = Console.ReadLine();
            return cartName;
        }
        public void DisplayCartPanel()
        {
            Console.WriteLine("Welcome To Cart \n" +
                              "1 - Submit A New Cart \n" +
                              "2 - Remove A Cart\n" +
                              "3 - Add A New Product To Your Cart \n" +
                              "4 - Remove A Product From Your Cart \n" +
                              "5 - Show Products In One Cart \n" +
                              "6 - Show Carts \n" +
                              "7 - See Cart Price\n" +
                              "8 - CheckOut Cart\n" +
                              "9 - PayAnotherInstallments");
            var enteredNumber = Convert.ToInt32(Console.ReadLine());
            switch (enteredNumber)
            {
                case 1:
                    var newCartName = GetCartName();
                    var cartGuid = _iCartService.AddNewCart(_accountCommand, newCartName);
                    _cartCommand.CartId = cartGuid;
                    DisplayCartPanel();
                    break;
                case 2:
                    var cartNameForRemove = GetCartName();
                    _cartCommand.CartName = cartNameForRemove;
                    _iCartService.RemoveCart(_accountCommand, _cartCommand);
                    DisplayCartPanel();
                    break;
                case 3:
                    var cartNameForAddProductToCart = GetCartName();
                    _cartCommand.CartName = cartNameForAddProductToCart;
                    ShowProductList();
                    DisplayCartPanel();
                    break;
                case 4:
                    var cartNameForRemoveProductFromCart = GetCartName();
                    _cartCommand.CartName = cartNameForRemoveProductFromCart;
                    Console.WriteLine("Enter ProductID");
                    var enteredProductId = Convert.ToInt32(Console.ReadLine());
                    _productCommand.ProductId = enteredProductId;
                    _iCartService.RemoveProductFromCart(_cartCommand, _productCommand);
                    DisplayCartPanel();
                    break;
                case 5:
                    var cartNameForShowProducts = GetCartName();
                    _cartCommand.CartName = cartNameForShowProducts;
                    var cartDto = _iCartService.ShowCartItem(_cartCommand);
                    if (cartDto.ProductDtos != null)
                        foreach (var product in cartDto.ProductDtos)
                            Console.WriteLine(product.Display());
                    else
                        new InvalidEmptyListException();
                    DisplayCartPanel();
                    break;
                case 6:
                    var cartList = _iCartService.ShowCarts();
                    foreach (var cart in cartList)
                        Console.WriteLine(cart.Name + " | " + cart.CartStateType);
                    DisplayCartPanel();
                    break;
                case 7:
                    var cartNameForTotalCost = GetCartName();
                    _cartCommand.CartName = cartNameForTotalCost;
                    var totalPriceCart = _iCartService.CartPriceCalculator(_cartCommand);
                    Console.WriteLine("TotalPrice : " + totalPriceCart + " Toman");
                    DisplayCartPanel();
                    break;
                case 8:
                    var cartNameForCheckout = GetCartName();
                    _cartCommand.CartName = cartNameForCheckout;
                    var paymentController = new PaymentController(_iAccountService, _accountCommand, _cartCommand, _iCartService, this, _iPaymentService);
                        paymentController.GetPaymentType();
                    var paymentType = paymentController.GetPaymentMethodType();
                    _paymentCommand.PaymentMethod = paymentType; 
                    if (paymentType.Equals(PaymentMethodType.Installment12Months) 
                        || paymentType.Equals(PaymentMethodType.Installment24Months) 
                        || paymentType.Equals(PaymentMethodType.Installment36Months))
                    {
                        var installmentDtos = _iPaymentService.GetInstallmentDtos(_cartCommand);
                        for (var index = 0; index < installmentDtos.Count; index++)
                        {
                            var installmentDto = installmentDtos[index];
                            var price = installmentDto.Price.ToString("N0");
                            Console.WriteLine(index + 1 + " - | Price: " + price + "Toman | Date: " +
                                              installmentDto.PayDate.ToString("dd/MM/yyyy") + " | InstallmentState : " + installmentDto.InstallmentStateType);
                        }
                    }
                    paymentController.PayMoneyOrNot(_paymentCommand);
                    DisplayCartPanel();
                    break;
                case 9:
                    var cartNameForSeeInstallments = GetCartName();
                    _cartCommand.CartName = cartNameForSeeInstallments;
                    var cartStateType = _iCartService.StateCartType(_cartCommand).CartStateType;
                    if (cartStateType.Equals(CartStateType.InstallmentCart))
                    {
                        var _installmentDtos = _iPaymentService.GetInstallmentDtos(_cartCommand);
                        for (var index = 0; index < _installmentDtos.Count; index++)
                        {
                            var installmentDto = _installmentDtos[index];
                            Console.WriteLine(index + 1 + " - | " + installmentDto.Price + " | " +
                                              installmentDto.PayDate.ToString("dd/MM/yyyy") + " | " +
                                              installmentDto.InstallmentStateType);
                        }
                        new PaymentController(_iAccountService,_accountCommand,_cartCommand,_iCartService,this,_iPaymentService).
                            PayMoneyOrNot(_paymentCommand);
                    }
                    else
                        throw new InvalidAccessDenied();
                    DisplayCartPanel();
                    break;
                default:
                    Console.WriteLine("Your Entered Number Is Wrong ... Try Again ...");
                    DisplayCartPanel();
                    break;
            }
        }
        public void ShowProductList()
        {
            while (true)
            {
                var productService = new ProductService();
                var productController = new ProductController(productService, _cartCommand);
                Console.WriteLine("\n 1 - Back To Panel \n 2 - CPU \n 3 - Ram \n 4 - GraphicCard \n 5 - HDD HardDisk \n 6 - SSD HardDisk" + " \n 7 - MotherBoard \n 8 - Power \n 9 - Case \n 10 - Keyboard \n 11 - Mouse");
                var enteredNumberStr = Console.ReadLine();
                int selectedItemId = Convert.ToInt32(enteredNumberStr);
                switch (selectedItemId)
                {
                    case 1:
                        DisplayCartPanel();
                        break;
                    case 2:
                        productController.Display(productService.GetCpuProducts());
                        break;
                    case 3:
                        productController.Display(productService.GetRamProducts());
                        break;
                    case 4:
                        productController.Display(productService.GetGraphicCardProducts());
                        break;
                    case 5:
                        productController.Display(productService.GetHddProducts());
                        break;
                    case 6:
                        productController.Display(productService.GetSsdProducts());
                        break;
                    case 7:
                        productController.Display(productService.GetMotherboardProducts());
                        break;
                    case 8:
                        productController.Display(productService.GetPowerProducts());
                        break;
                    case 9:
                        productController.Display(productService.GetCaseProducts());
                        break;
                    case 10:
                        productController.Display(productService.GetKeyboardProducts());
                        break;
                    case 11:
                        productController.Display(productService.GetMouseProducts());
                        break;
                    default:
                        Console.WriteLine("Wrong Number...");
                        continue;
                }
                break;
            }
        }
    }
}
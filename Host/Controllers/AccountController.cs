using System;
using ApplicationService.Command;
using ApplicationService.Services;
namespace Host.Controllers
{
    public class AccountController
    {
        private AccountCommand _accountCommand { get; set; }
        private string _username { get; set; }
        private string _password { get; set; }

        public AccountController(AccountCommand accountCommand)
        {
            _accountCommand = accountCommand;
        }
        public void View()
        {
            Console.WriteLine("\n..:: LoginPage ::..");
            Console.WriteLine("\nPlease Enter Your Username");
            _username = Console.ReadLine();
            Console.WriteLine("Please Enter Your Password");
            _password = Console.ReadLine();
            _accountCommand.Username = _username;
            _accountCommand.Password = _password;
            CheckUser(_accountCommand);
        }
        /// <summary>
        /// اعتبارسنجی یوزر
        /// </summary>
        public void CheckUser(AccountCommand accountCommand)
        {
            accountCommand.Validate();
            new AccountService().UserLogin(accountCommand);
        }
        /// <summary>
        /// یوزر وارد شد
        /// </summary>
        public void Login()
        {
            Console.WriteLine(_username + " Login Successful");
        }
    }
}
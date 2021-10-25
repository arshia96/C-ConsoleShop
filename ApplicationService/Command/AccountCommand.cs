using Infrastructure.Exceptions;

namespace ApplicationService.Command
{
    public class AccountCommand : CommandBase
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// رمزعبور
        /// </summary>
        public string Password { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                throw new InvalidUserException();
        }
    }
}
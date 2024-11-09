using Common.Application;
using System.Net.Sockets;

namespace Application.User.Register
{
    public class RegisterUserCommand : IBaseCommand
    {

        /// <summary>
        /// Properties required to successfully create a user account.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public RegisterUserCommand(string firstName, string lastName, string userName, string email, string password, string phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
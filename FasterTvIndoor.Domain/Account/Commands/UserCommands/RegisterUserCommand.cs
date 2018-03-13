using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.Account.Commands.UserCommands
{
    public class RegisterUserCommand
    {
        public RegisterUserCommand(string email, string name, string lastName, string password,string nickName)
        {
            this.Email = email;
            this.Name = name;
            this.LastName = lastName;
            this.Password = password;
            this.NickName = nickName;
            this.DataRegister = DateTime.Now;
        }

        public string Email { get; set; }
        public string  Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public DateTime DataRegister { get; set; }
        
    }
}

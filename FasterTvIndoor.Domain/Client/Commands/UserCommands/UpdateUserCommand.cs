using System;

namespace FasterTvIndoor.Domain.Client.Commands.UserCommands
{
    public class UpdateUserCommand
    {        
        public UpdateUserCommand(int idUser,string email,string name, string lastName, string password, bool isAdmin, int idProfileUser)
        {
            this.IdUser = idUser;
            this.Email = email;
            this.Name = name;
            this.LastName = lastName;
            this.Password = password;
            this.IsAdmin = isAdmin;
            this.IdProfileUser = idProfileUser;
        }
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int IdProfileUser { get; set; }
        public DateTime DataRegister { get; set; }
    }
}

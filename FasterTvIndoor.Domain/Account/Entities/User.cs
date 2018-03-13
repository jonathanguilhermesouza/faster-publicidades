using FasterTvIndoor.Domain.BackOffice.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.Account.Scopes;
using FasterTvIndoor.SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.Account.Commands.UserCommands;
using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.Client.Entities;
using FasterTvIndoor.Domain.Entities;

namespace FasterTvIndoor.Domain.Account.Entities
{
    public class User
    {
        protected User() { }

        public User(string email, string name, string lastName, string password, string nickName, ICollection<AddressUser> listAddressUser, ICollection<PhoneUser> listPhoneUser)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = StringHelper.Encrypt(password);
            this.NickName = nickName;
            this.DateRegister = DateTime.Now;
            this.StatusUser = EStatusUser.Habilitado;
            this.IdProfileUser = 1;
            this.ListAddressUser = listAddressUser;
            this.ListPhoneUser = listPhoneUser;
        }

        public User(string email, string name, string lastName, string password, string nickName)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = StringHelper.Encrypt(password);
            this.NickName = nickName;
            this.DateRegister = DateTime.Now;
            this.StatusUser = EStatusUser.Habilitado;
            this.IdProfileUser = 1;
        }

        public int IdUser { get; set; }
        public int IdProfileUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string NickName { get; set; }
        public DateTime DateRegister { get; private set; }
        public virtual ProfileUser ProfileUser { get; private set; }
        public EStatusUser StatusUser { get; set; }
        public virtual ICollection<AddressUser> ListAddressUser { get; private set; }
        public virtual ICollection<PhoneUser> ListPhoneUser { get; private set; }
        public virtual ICollection<EmployeeCompany> ListEmployedCompany { get; private set; }
        public virtual ICollection<AccountCurrent> ListAccountCurrent { get; private set; }

        public void Register(bool searchEmail,bool searchNickname)
        {
            if (!this.RegisterUserScopeIsValid(searchEmail, searchNickname))
                return;

            this.IdProfileUser = 4;
        }

        public void Authenticate(string email, string password)
        {
            if (!this.AuthenticateUserScopeIsValid(email, password))
                return;
        }

        public void Update(UpdateUserCommand command)
        {
            //if (!this.UpdateUserScopeIsValid(command))
            //    return;

            this.Email = command.Email;
            this.Name = command.Name;
            this.LastName = command.LastName;
            this.Password = command.Password;
            this.IdProfileUser = command.IdProfileUser;
        }
    }
}

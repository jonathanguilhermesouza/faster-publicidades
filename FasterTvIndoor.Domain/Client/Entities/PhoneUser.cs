using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.Entities.Model;
using FasterTvIndoor.Domain.Client.Commands.PhoneUserCommands;
using FasterTvIndoor.Domain.Client.Scopes;

namespace FasterTvIndoor.Domain.Entities
{
    public class PhoneUser : Phone
    {
        public PhoneUser() {}
        public PhoneUser(string number, int idUser)
        {
            this.Number = number;
            this.IdUser = idUser;
        }
        public int IdPhoneUser{ get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        public void Create()
        {
            if (!this.CreatePhoneUserScopeIsValid())
                return;
        }

        public void Update(UpdatePhoneUserCommand command)
        {
            if (!this.UpdatePhoneUserScopeIsValid(command))
              return;

            this.Number = command.Number;
        }

        public void Delete(DeletePhoneUserCommand command)
        {
            this.IdPhoneUser = command.IdPhoneUser;
        }


    }
}

using FasterTvIndoor.Domain.Entities.Model;
using FasterTvIndoor.Domain.FasterAdministration.Commands.PhoneCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class PhoneCompany : Phone
    {
        public PhoneCompany(){}
        public PhoneCompany(int idPhoneCompany,string number, int idCompany)
        {
            this.IdPhoneCompany = idPhoneCompany;
            this.Number = number;
            this.IdCompany = idCompany;
        }
        public PhoneCompany(string number)
        {
            this.Number = number;
        }
        public PhoneCompany(string number, int idCompany)
        {
            this.Number = number;
            this.IdCompany = idCompany;
        }
        public int IdPhoneCompany { get; private set; }
        public int IdCompany { get; set; }
        public virtual Company Company { get; private set; }

        public void Create()
        {
            if (!this.CreatePhoneCompanyScopeIsValid())
                return;
        }

        public void Update(UpdatePhoneCompanyCommand command)
        {
            if (!this.UpdatePhoneCompanyScopeIsValid(command))
                return;

            this.Number = command.Number;      
        }

        public void Delete(DeletePhoneCompanyCommand command)
        {
            this.IdPhoneCompany = command.IdPhoneCompany;
        }

    }
}

using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.BackOffice.Commands.EmployeeCompany;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.BackOffice.Scopes;

namespace FasterTvIndoor.Domain.BackOffice.Entities
{
    public class EmployeeCompany
    {
        public EmployeeCompany(){}
        public EmployeeCompany(string cpf, int idSectorCompany, int idCompany, User user)
        {
            this.Cpf = cpf;           
            this.IdSectorCompany = idSectorCompany;
            this.IdCompany = idCompany;
            this.User = user;
        }
        public int IdEmployeeCompany { get; private set; }
        public int IdUser { get; set; }
        public int IdSectorCompany { get; set; }
        public int IdCompany { get; set; }
        public string Cpf { get; private set; }        
        public virtual User User { get; private set; }
        public virtual SectorCompany SectorCompany { get; private set; }
        public virtual Company Company { get; private set; }

        public void Update(UpdateEmployeeCompanyCommand command)
        {
            if (!this.UpdateEmployeeCompanyScopeIsValid(command))
              return;

            this.Cpf = command.Cpf;
            this.IdSectorCompany = command.IdSectorCompany;
        }

        public void Create()
        {
            if (!this.CreateEmployeeCompanyScopeIsValid())
              return;
        }

    }
}

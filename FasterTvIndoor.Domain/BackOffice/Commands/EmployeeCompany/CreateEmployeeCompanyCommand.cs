using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Entities;

namespace FasterTvIndoor.Domain.BackOffice.Commands.EmployeeCompany
{
    public class CreateEmployeeCompanyCommand
    {
        public CreateEmployeeCompanyCommand(string cpf, int idSectorCompany, int idCompany, User user)
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

    }
}

using FasterTvIndoor.Domain.FasterAdministration.Entities;

namespace FasterTvIndoor.Domain.BackOffice.Commands.EmployeeCompany
{
    public class UpdateEmployeeCompanyCommand
    {
        public UpdateEmployeeCompanyCommand(int idEmployeeCompany,string cpf, int idSectorCompany)
        {
            this.IdEmployeeCompany = idEmployeeCompany;
            this.Cpf = cpf;           
            this.IdSectorCompany = idSectorCompany;
        }

        public int IdEmployeeCompany { get; private set; }
        public int IdSectorCompany { get; set; }
        public string Cpf { get; private set; }   
        public virtual SectorCompany SectorCompany { get; private set; }

    }
}

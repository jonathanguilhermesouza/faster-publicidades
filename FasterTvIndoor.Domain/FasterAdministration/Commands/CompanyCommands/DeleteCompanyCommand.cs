using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands
{
    public class DeleteCompanyCommand
    {
        public DeleteCompanyCommand(int idCompany,EStatusCompany statusCompany)
        {
            this.IdCompany = idCompany;
            this.StatusCompany = statusCompany;
        }
        public int IdCompany { get; set; }
        public EStatusCompany StatusCompany { get; set; }
        
    }
}

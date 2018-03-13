
namespace FasterTvIndoor.Domain.BackOffice.Commands.EmployeeCompany
{
    public class DeleteEmployeeCompanyCommand
    {
        public DeleteEmployeeCompanyCommand(int idEmployeeCompany)
        {
            this.IdEmployeeCompany = idEmployeeCompany;
        }
        public int IdEmployeeCompany { get; set; }
    }
}

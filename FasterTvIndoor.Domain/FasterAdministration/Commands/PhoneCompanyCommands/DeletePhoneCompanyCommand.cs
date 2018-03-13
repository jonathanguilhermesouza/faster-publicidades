
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PhoneCompanyCommands
{
    public class DeletePhoneCompanyCommand
    {
        public DeletePhoneCompanyCommand(int idPhoneCompany)
        {
            this.IdPhoneCompany = idPhoneCompany;
        }
        public int IdPhoneCompany { get; set; }
    }
}

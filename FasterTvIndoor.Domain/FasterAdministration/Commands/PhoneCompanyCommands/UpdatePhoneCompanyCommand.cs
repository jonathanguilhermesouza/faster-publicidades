
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PhoneCompanyCommands
{
    public class UpdatePhoneCompanyCommand
    {
        public UpdatePhoneCompanyCommand(int idPhoneCompany,string number)
        {
            this.IdPhoneCompany = idPhoneCompany;
            this.Number = number;
        }
        public int IdPhoneCompany { get; set; }
        public string Number { get; set; }
    }
}

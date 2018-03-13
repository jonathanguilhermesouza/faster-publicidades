
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PhoneCompanyCommands
{
    public class CreatePhoneCompanyCommand
    {
        public CreatePhoneCompanyCommand(string number,int idCompany)
        {
            this.Number = number;
            this.IdCompany = idCompany;
        }
        public string Number { get; set; }
        public int IdCompany { get; set; }
    }
}

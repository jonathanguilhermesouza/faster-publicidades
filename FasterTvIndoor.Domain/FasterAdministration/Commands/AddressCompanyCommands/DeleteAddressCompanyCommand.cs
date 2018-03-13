
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.AddressCompanyCommands
{
    public class DeleteAddressCompanyCommand
    {
        public DeleteAddressCompanyCommand(int idAddressCompany)
        {
            this.IdAddressCompany = idAddressCompany;  
        }
        public int IdAddressCompany { get; set; }
    }
}

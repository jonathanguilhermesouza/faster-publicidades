using FasterTvIndoor.Domain.FasterAdministration.Commands.AddressCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IAddressCompanyApplicationService
    {
        AddressCompany GetById(int id);
        AddressCompany Update(UpdateAddressCompanyCommand command);
        AddressCompany Delete(DeleteAddressCompanyCommand command);
    }
}

using FasterTvIndoor.Domain.Client.Commands.AddressUserCommands;
using FasterTvIndoor.Domain.Client.Entities;

namespace FasterTvIndoor.Domain.Client.Services
{
    public interface IAddressUserApplicationService
    {
        AddressUser GetById(int id);
        AddressUser Create(CreateAddressUserCommand command);
        AddressUser Update(UpdateAddressUserCommand command);
        AddressUser Delete(DeleteAddressUserCommand command);
    }
}

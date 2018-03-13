using FasterTvIndoor.Domain.Client.Commands.PhoneUserCommands;
using FasterTvIndoor.Domain.Entities;

namespace FasterTvIndoor.Domain.Client.Services
{
    public interface IPhoneUserApplicationService
    {
        PhoneUser GetById(int id);
        PhoneUser Update(UpdatePhoneUserCommand command);
        PhoneUser Delete(DeletePhoneUserCommand command);
        PhoneUser Create(CreatePhoneUserCommand command);
    }
}

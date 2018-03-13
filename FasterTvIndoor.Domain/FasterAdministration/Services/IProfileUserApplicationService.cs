using FasterTvIndoor.Domain.FasterAdministration.Commands.ProfileUserCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IProfileUserApplicationService
    {
        List<ProfileUser> GetAll();
        List<ProfileUser> GetByRange(int skip, int take);
        ProfileUser GetById(int id);
        ProfileUser Create(CreateProfileUserCommand command);
        ProfileUser Update(UpdateProfileUserCompanyCommand command);
        ProfileUser Delete(DeleteProfileUserCommand command);
        int GetCount();
    }
}

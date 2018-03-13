using FasterTvIndoor.Domain.FasterAdministration.Commands.ProfileUserCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class ProfileUserApplicationService : ApplicationService, IProfileUserApplicationService
    {
        private IProfileUserRepository _repository;
        public ProfileUserApplicationService(IProfileUserRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<ProfileUser> GetAll()
        {
            return _repository.GetAll();
        }

        public List<ProfileUser> GetByRange(int skip, int take)
        {
            return _repository.GetByRange(skip, take);
        }

        public ProfileUser GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ProfileUser Create(CreateProfileUserCommand command)
        {
            var profile = new ProfileUser(command.Profile);
            profile.Register();
            _repository.Create(profile);
            
            if (Commit())
                return profile;

            return null;
        }

        public ProfileUser Update(UpdateProfileUserCompanyCommand command)
        {
            var profile = _repository.GetById(command.ProfileId);
            profile.UpdateProfile(command.Profile);
            _repository.Update(profile);
            
            if (Commit())
                return profile;

            return null;
        }

        public ProfileUser Delete(DeleteProfileUserCommand command)
        {
            var profile = _repository.GetById(command.ProfileId);
            _repository.Delete(profile);
            
            if (Commit())
                return profile;

            return null;
        }

        public int GetCount()
        {
            return _repository.GetCount();
        }
    }
}

using FasterTvIndoor.Domain.Client.Commands.PhoneUserCommands;
using FasterTvIndoor.Domain.Client.Repositories;
using FasterTvIndoor.Domain.Client.Services;
using FasterTvIndoor.Domain.Entities;
using FasterTvIndoor.Infrastructure.Persistence;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.Client
{
    public class PhoneUserApplicationService : ApplicationService, IPhoneUserApplicationService
    {
        private IPhoneUserRepository _repository;
        public PhoneUserApplicationService(IPhoneUserRepository repository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _repository = repository;
        }

        public List<PhoneUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhoneUser GetById(int id)
        {
            return _repository.GetById(id);
        }

        public PhoneUser Update(UpdatePhoneUserCommand command)
        {
            var phone = _repository.GetById(command.IdPhoneUser);
            phone.Update(command);
            _repository.Update(phone);

            if (Commit())
                return phone;

            return null;
        }

        public PhoneUser Delete(DeletePhoneUserCommand command)
        {
            var phone = _repository.GetById(command.IdPhoneUser);
            _repository.Delete(phone);

            if (Commit())
                return phone;

            return null;
        }

        public PhoneUser Create(CreatePhoneUserCommand command)
        {
            var phone = new PhoneUser(command.Number, command.IdUser);
            phone.Create();
            _repository.Create(phone);

            if (Commit())
                return phone;

            return null;
        }
    }
}

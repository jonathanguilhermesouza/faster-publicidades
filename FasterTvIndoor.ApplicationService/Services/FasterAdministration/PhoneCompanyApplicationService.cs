using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Collections.Generic;
using FasterTvIndoor.Infrastructure.Persistence;
using FasterTvIndoor.Domain.FasterAdministration.Commands.PhoneCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class PhoneCompanyApplicationService : ApplicationService, IPhoneCompanyApplicationService
    {
        private IPhoneCompanyRepository _repository;
        public PhoneCompanyApplicationService(IPhoneCompanyRepository repository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _repository = repository;
        }

        public List<PhoneCompany> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhoneCompany GetById(int id)
        {
            return _repository.GetById(id);
        }

        public PhoneCompany Update(UpdatePhoneCompanyCommand command)
        {
            var phone = _repository.GetById(command.IdPhoneCompany);
            phone.Update(command);
            _repository.Update(phone);

            if (Commit())
                return phone;

            return null;
        }

        public PhoneCompany Delete(DeletePhoneCompanyCommand command)
        {
            var phone = _repository.GetById(command.IdPhoneCompany);
            _repository.Delete(phone);

            if (Commit())
                return phone;

            return null;
        }

        public PhoneCompany Create(CreatePhoneCompanyCommand command)
        {
            var phone = new PhoneCompany(command.Number,command.IdCompany);
            phone.Create();
            _repository.Create(phone);

            if (Commit())
                return phone;

            return null;
        }
    }
}

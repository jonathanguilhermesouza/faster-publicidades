using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.BackOffice.Commands.EmployeeCompany;
using FasterTvIndoor.Domain.BackOffice.Entities;
using FasterTvIndoor.Domain.BackOffice.Repositories;
using FasterTvIndoor.Domain.BackOffice.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.BackOffice
{
    public class EmployeeCompanyApplicationService : ApplicationService, IEmployeeCompanyApplicationService
    {
        private IEmployeeCompanyRepository _repository;
        public EmployeeCompanyApplicationService(IEmployeeCompanyRepository repository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _repository = repository;
        }

        public int GetCount(string word, EStatusUser status)
        {
            return _repository.GetCount(word, status);
        }

        public List<EmployeeCompany> GetByRange(int skip, string word, EStatusUser status)
        {
            return _repository.GetByRange(skip, word, status);
        }

        public EmployeeCompany GetById(int id)
        {
            return _repository.GetById(id);
        }

        public EmployeeCompany GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public EmployeeCompany Create(CreateEmployeeCompanyCommand command)
        {
            var employee = new EmployeeCompany(command.Cpf, command.IdSectorCompany, command.IdCompany,command.User);
            employee.Create();
            _repository.Create(employee);

            if (Commit())
                return employee;

            return null;
        }

        public EmployeeCompany Update()
        {
            throw new NotImplementedException();
        }

        public EmployeeCompany Delete(DeleteEmployeeCompanyCommand command)
        {
            var employee = _repository.GetById(command.IdEmployeeCompany);
            _repository.Delete(employee);

            if (Commit())
                return employee;

            return null;
        }

        public EmployeeCompany Update(UpdateEmployeeCompanyCommand command)
        {
            var employee = _repository.GetById(command.IdEmployeeCompany);
            employee.Update(command);
            _repository.Update(employee);

            if (Commit())
                return employee;

            return null;
        
        }
    }
}

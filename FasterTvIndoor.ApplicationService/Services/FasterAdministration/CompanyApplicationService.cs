using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;
using System;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence;
using FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.Account.Entities;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class CompanyApplicationService : ApplicationService, ICompanyApplicationService
    {
        private ICompanyRepository _repository;
        public CompanyApplicationService(ICompanyRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<Company> GetByRange(int skip, int take, string word, EStatusCompany status)
        {
            return _repository.GetByRange(skip, take, word, status);
        }

        public Company GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int GetCount(string word, EStatusCompany status)
        {
            return _repository.GetCount(word, status);
        }

        public Company Create(CreateCompanyCommand command)
        {
            var company = new Company(command.CompanyName, command.FantasyName, command.StateInscription, command.Cnpj, command.Email, command.ClassificationCompany, command.SizeCompany, command.ListAddressCompany, command.ListPhonesCompany);
            company.Register();
            _repository.Create(company);

            if (Commit())
                return company;

            return null;
        }

        public Company Update(UpdateCompanyCommand command)
        {
            var company = _repository.GetById(command.IdCompany);
            company.UpdateCompany(command, company.StatusCompany);
            _repository.Update(company);

            if (Commit())
                return company;

            return null;
        }

        public Company Delete(DeleteCompanyCommand command)
        {
            var company = _repository.GetById(command.IdCompany);
            company.DeleteCompany(command);
            _repository.Delete(company);

            if (Commit())
                return company;

            return null;
        }

    }
}

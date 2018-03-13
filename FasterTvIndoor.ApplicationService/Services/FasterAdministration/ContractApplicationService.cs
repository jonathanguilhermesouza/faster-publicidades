using FasterTvIndoor.Domain.FasterAdministration.Commands.ContractCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class ContractApplicationService : ApplicationService, IContractApplicationService
    {
        private IContractRepository _repository;
        private ICompanyRepository _repositoryCompany;

        public ContractApplicationService(IContractRepository repository, ICompanyRepository repositoryCompany, IUnitOfWork unityOfWork)
            : base(unityOfWork)
        {
            this._repository = repository;
            this._repositoryCompany = repositoryCompany;
        }
        public List<Contract> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Contract> GetByRange(int skip, int take, string word, EStatusContract statusContract)
        {
            return _repository.GetByRange(skip, take, word, statusContract);
        }

        public Contract GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Contract Create(CreateContractCommand command)
        {
            var contract = new Contract(command.DateStart, command.DateEnd, command.IdCompany, command.IdDayOfMonth/*,command.IdPlan*/, command.Note);
            contract.Register();
            _repository.Create(contract);

            //Atualiza a empresa com contrato
            var company = _repositoryCompany.GetById(command.IdCompany);
            company.UpdateHaveContract(true);
            _repositoryCompany.Update(company);

            if (Commit())
                return contract;

            return null;
        }

        public Contract Update(UpdateContractCommand command)
        {
            var contract = _repository.GetById(command.IdContract);
            contract.UpdateContract(command);
            _repository.Update(contract);


            //Atualiza a empresa com contrato
            if (!command.StatusContract.Equals(EStatusContract.Vigente))
            {
                var company = _repositoryCompany.GetById(command.IdCompany);
                company.UpdateHaveContract(false);
                _repositoryCompany.Update(company);
            }

            if (Commit())
                return contract;

            return null;
        }

        public Contract Cancel(CancelContractCommand command)
        {
            var contract = _repository.GetById(command.IdContract);
            contract.CancelContract(command);

            if (Commit())
                return contract;

            return null;
        }

        public int GetCount(string word, EStatusContract status)
        {
            return _repository.GetCount(word, status);
        }

    }
}

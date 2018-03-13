using FasterTvIndoor.Domain.FasterAdministration.Commands.ControlLoanCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class ControlLoanApplicationService : ApplicationService, IControlLoanApplicationService
    {

        private IControlLoanRepository _repository;
        private IEquipmentRepository _repositoryEquipment;

        public ControlLoanApplicationService(IControlLoanRepository repository, IEquipmentRepository repositoryEquipment, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
            this._repositoryEquipment = repositoryEquipment;
        }

        public List<ControlLoan> GetAll()
        {
            return _repository.GetAll();
        }
        
        public List<ControlLoan> GetAllControlLoanEquipmentByVideo(int idVideo, int idTypeEquipment, EStatusControlLoan status)
        {
            return _repository.GetAllControlLoanEquipment(idTypeEquipment, status);
        }

        public List<ControlLoan> GetAllControlLoanEquipment(int idTypeEquipment, EStatusControlLoan status)
        {
            return _repository.GetAllControlLoanEquipment(idTypeEquipment, status);
        }

        public List<ControlLoan> GetByRange(int skip, int take, string word, EStatusControlLoan status)
        {
            return _repository.GetByRange(skip, take, word,status);
        }

        public ControlLoan GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ControlLoan Create(CreateControlLoanCommand command)
        {
            var controlLoan = new ControlLoan(command.DateLocation,command.DateEndLocation,command.Note,command.IdCompany,command.IdEquipment);
            controlLoan.Create(command);
            _repository.Create(controlLoan);

            //Atualiza o equipamento para emprestado
            var equipment = _repositoryEquipment.GetById(command.IdEquipment);
            equipment.UpdateStatus(EStatusEquipment.Emprestado);
            _repositoryEquipment.Update(equipment);
            
            if (Commit())
                return controlLoan;

            return null;
        }

        public ControlLoan Update(UpdateControlLoanCommand command)
        {
            var controlLoan = _repository.GetById(command.IdControlLoan);
            controlLoan.Update(command,controlLoan.StatusControlLoan);
            _repository.Update(controlLoan);
            
            if (Commit())
                return controlLoan;

            return null;
        }

        public ControlLoan Delete(DeleteControlLoanCommand command)
        {
            var controlLoan = _repository.GetById(command.IdControlLoan);
            controlLoan.Delete();
            _repository.Delete(controlLoan);

            //Atualiza o equipamento para emprestado
            var equipment = _repositoryEquipment.GetById(controlLoan.Equipment.IdEquipment);
            equipment.UpdateStatus(EStatusEquipment.Disponível);
            _repositoryEquipment.Update(equipment);
            
            if (Commit())
                return controlLoan;

            return null;
        }

        public int GetCount(string word, EStatusControlLoan status)
        {
            return _repository.GetCount(word,status);
        }
    }
}

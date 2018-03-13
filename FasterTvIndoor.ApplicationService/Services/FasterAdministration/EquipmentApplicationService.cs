using FasterTvIndoor.Domain.FasterAdministration.Commands.EquipmentCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Commands.ProfileUserCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class EquipmentApplicationService : ApplicationService, IEquipmentApplicationService
    {
        private IEquipmentRepository _repository;
        public EquipmentApplicationService(IEquipmentRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }
        public List<Equipment> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Equipment> GetAllEquipmentControlLoan(string word, EStatusEquipment statusEquipment, EStatusControlLoan statusControlLoan)
        {
            return _repository.GetAllEquipmentControlLoan(word, statusEquipment, statusControlLoan);
        }

        public List<Equipment> GetByRange(int skip, int take, string word, EStatusEquipment status)
        {
            return _repository.GetByRange(skip, take, word, status);
        }

        public Equipment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Equipment Create(CreateEquipmentCommand command)
        {
            var equipment = new Equipment(command.IdTypeEquipment, command.Description, command.Model, command.SerialNumber, command.DateBuy, command.Patrimony);
            equipment.Create();
            _repository.Create(equipment);

            if (Commit())
                return equipment;

            return null;
        }

        public Equipment Update(UpdateEquipmentCommand command)
        {
            var equipment = _repository.GetById(command.IdEquipment);
            equipment.Update(command, equipment.StatusEquipment);
            _repository.Update(equipment);

            if (Commit())
                return equipment;

            return null;
        }

        public Equipment Delete(DeleteEquipmentCommand command)
        {
            var equipment = _repository.GetById(command.IdEquipment);
            equipment.Delete();
            _repository.Delete(equipment);

            if (Commit())
                return equipment;

            return null;
        }

        public int GetCount(string word, EStatusEquipment status)
        {
            return _repository.GetCount(word, status);
        }

    }
}

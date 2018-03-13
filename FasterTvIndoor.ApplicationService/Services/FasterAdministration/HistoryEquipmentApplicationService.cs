using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Commands.HistoryEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class HistoryEquipmentApplicationService : ApplicationService, IHistoryEquipmentApplicationService
    {
        private IHistoryEquipmentRepository _repository;

        public HistoryEquipmentApplicationService(IHistoryEquipmentRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public HistoryEquipment Create(CreateHistoryEquipmentCommand command)
        {
            var history = new HistoryEquipment(command.IdVideo,command.IdEquipment, command.IdCompany, command.Plan, command.Action, command.Value);
            history.Create();
            _repository.Create(history);

            if (Commit())
                return history;

            return null;
        }

        public List<HistoryEquipment> GetAll()
        {
            return _repository.GetAll();
        }

        public HistoryEquipment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<HistoryEquipment> GetByRangeEquipment(int skip, int take, int id)
        {
            return _repository.GetByRangeEquipment(skip, take, id);
        }

        public List<HistoryEquipment> GetByRangeCompany(int skip, int take, int id)
        {
            return _repository.GetByRangeCompany(skip, take, id);
        }

        public int GetCount(int id)
        {
            return _repository.GetCount(id);
        }

        public int GetCountByCompany(int id)
        {
            return _repository.GetCountByCompany(id);
        }

        public HistoryEquipment Update(UpdateHistoryEquipmentCommand command)
        {
            var history = _repository.GetById(command.IdHistoryEquipment);
            history.Update(command);
            _repository.Update(history);

            if (Commit())
                return history;

            return null;
        }
    }
}

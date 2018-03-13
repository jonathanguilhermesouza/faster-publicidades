using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration;
using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class TypeEquipmentApplicationService : ApplicationService,ITypeEquipmentApplicationService
    {
        private ITypeEquipmentRepository _repository;
        public TypeEquipmentApplicationService(ITypeEquipmentRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<TypeEquipment> GetAll()
        {
            return _repository.GetAll();
        }

        public List<TypeEquipment> GetByRange(int skip, int take)
        {
            return _repository.GetByRange(skip, take);
        }

        public TypeEquipment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TypeEquipment Create(CreateTypeEquipmentCommand command)
        {
            var equipment = new TypeEquipment(command.Type);
            equipment.Create();
            _repository.Create(equipment);
            
            if (Commit())
                return equipment;

            return null;
        }

        public TypeEquipment Update(UpdateTypeEquipmentCommand command)
        {
            var equipment = _repository.GetById(command.IdTypeEquipment);
            equipment.Update(command);
            _repository.Update(equipment);
            
            if (Commit())
                return equipment;

            return null;
        }

        public TypeEquipment Delete(DeleteTypeEquipmentCommand command)
        {
            var equipment = _repository.GetById(command.IdTypeEquipment);
            _repository.Delete(equipment);
            
            if (Commit())
                return equipment;

            return null;
        }

        public int GetCount()
        {
            return _repository.GetCount();
        }
    }
}

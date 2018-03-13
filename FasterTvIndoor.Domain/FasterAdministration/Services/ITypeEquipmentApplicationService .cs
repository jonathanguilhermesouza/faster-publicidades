using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public interface ITypeEquipmentApplicationService
    {
        List<TypeEquipment> GetAll();
        List<TypeEquipment> GetByRange(int skip, int take);
        TypeEquipment GetById(int id);
        TypeEquipment Create(CreateTypeEquipmentCommand command);
        TypeEquipment Update(UpdateTypeEquipmentCommand command);
        TypeEquipment Delete(DeleteTypeEquipmentCommand command);
        int GetCount();
    }
}

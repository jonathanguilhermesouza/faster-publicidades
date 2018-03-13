using FasterTvIndoor.Domain.FasterAdministration.Commands.HistoryEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IHistoryEquipmentApplicationService
    {
        List<HistoryEquipment> GetAll();
        List<HistoryEquipment> GetByRangeEquipment(int skip, int take, int id);
        List<HistoryEquipment> GetByRangeCompany(int skip, int take, int id);
        HistoryEquipment GetById(int id);
        HistoryEquipment Create(CreateHistoryEquipmentCommand command);
        HistoryEquipment Update(UpdateHistoryEquipmentCommand command);
        int GetCount(int id);
        int GetCountByCompany(int id);
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IHistoryEquipmentRepository
    {
        List<HistoryEquipment> GetAll();
        List<HistoryEquipment> GetByRangeEquipment(int skip, int take, int id);
        List<HistoryEquipment> GetByRangeCompany(int skip, int take, int id);
        HistoryEquipment GetById(int id);
        void Create(HistoryEquipment history);
        void Update(HistoryEquipment history);
        int GetCount(int id);
        int GetCountByCompany(int id);
    }
}

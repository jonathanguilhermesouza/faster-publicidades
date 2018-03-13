using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAll();
        List<Equipment> GetAllEquipmentControlLoan(string word, EStatusEquipment statusEquipment, EStatusControlLoan statusControlLoan);
        List<Equipment> GetByRange(int skip, int take, string word, EStatusEquipment status);
        Equipment GetById(int id);
        void Create(Equipment profile);
        void Update(Equipment profile);
        void Delete(Equipment profile);
        int GetCount(string word, EStatusEquipment status);
    }
}

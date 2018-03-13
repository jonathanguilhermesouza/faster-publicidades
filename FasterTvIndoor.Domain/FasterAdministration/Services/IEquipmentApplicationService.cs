using FasterTvIndoor.Domain.FasterAdministration.Commands.EquipmentCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IEquipmentApplicationService
    {
        List<Equipment> GetAll();
        List<Equipment> GetAllEquipmentControlLoan(string word, EStatusEquipment statusEquipment, EStatusControlLoan statusControlLoan);
        List<Equipment> GetByRange(int skip, int take, string word, EStatusEquipment status);
        Equipment GetById(int id);
        Equipment Create(CreateEquipmentCommand command);
        Equipment Update(UpdateEquipmentCommand command);
        Equipment Delete(DeleteEquipmentCommand command);
        int GetCount(string word, EStatusEquipment status);
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IStatusEquipmentRepository
    {
        List<StatusEquipment> GetAll();
    }
}

using FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface ITypeEquipmentRepository
    {
        List<TypeEquipment> GetAll();
        List<TypeEquipment> GetByRange(int skip, int take);
        TypeEquipment GetById(int id);
        void Create(TypeEquipment type);
        void Update(TypeEquipment type);
        void Delete(TypeEquipment type);
        int GetCount();
    }
}

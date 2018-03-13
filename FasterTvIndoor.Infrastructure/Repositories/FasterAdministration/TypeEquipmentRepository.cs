using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class TypeEquipmentRepository : ITypeEquipmentRepository
    {
        private FasterTvIndoorDataContext _context;
        public TypeEquipmentRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<TypeEquipment> GetAll()
        {
            return _context.TypeEquipment.ToList();
        }

        public List<TypeEquipment> GetByRange(int skip, int take)
        {
            return _context.TypeEquipment
                .OrderBy(x => x.Type)
                .Skip((skip - 1) * take)
                .Take(take)
                .ToList();
        }

        public TypeEquipment GetById(int id)
        {
            return _context.TypeEquipment.Find(id);
        }

        public void Create(TypeEquipment type)
        {
            _context.TypeEquipment.Add(type);
        }

        public void Update(TypeEquipment type)
        {
            _context.Entry<TypeEquipment>(type).State = EntityState.Modified;
        }

        public void Delete(TypeEquipment type)
        {
            _context.TypeEquipment.Remove(type);
        }

        public int GetCount()
        {
            return _context.TypeEquipment.Count();
        }
    }
}

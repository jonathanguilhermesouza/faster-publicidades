using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class SectorCompanyRepository : ISectorCompanyRepository
    {
        private FasterTvIndoorDataContext _context;
        public SectorCompanyRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<SectorCompany> GetAll()
        {
            return _context.SectorCompany.ToList();
        }

        public List<SectorCompany> GetByRange(int skip, int take)
        {
            return _context.SectorCompany
                .OrderBy(x => x.IdSectorCompany).Skip((skip - 1) * take).Take(take).ToList();
        }

        public SectorCompany GetById(int id)
        {
            return _context.SectorCompany.SingleOrDefault(x => x.IdSectorCompany == id);
        }

        public void Create(SectorCompany sector)
        {
            _context.SectorCompany.Add(sector);
        }

        public void Update(SectorCompany sector)
        {
            _context.Entry<SectorCompany>(sector).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(SectorCompany sector)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            return _context.SectorCompany.Count();
        }
    }
}

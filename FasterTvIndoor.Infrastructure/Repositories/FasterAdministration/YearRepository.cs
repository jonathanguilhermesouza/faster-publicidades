using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Linq;
using System.Data.Entity;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class YearRepository : IYearRepository
    {
        private FasterTvIndoorDataContext _context;
        public YearRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public void Create(Year year)
        {
            _context.Year.Add(year);
        }

        public void Delete(Year year)
        {
            throw new NotImplementedException();
        }

        public List<Year> GetAll()
        {
            return _context.Year.ToList();
        }

        public Year GetById(int id)
        {
            return _context.Year
                .SingleOrDefault(x => x.IdYear == id);
        }

        public int GetCount(string word)
        {
            return _context.Year.Count();
        }

        public void Update(Year year)
        {
            _context.Entry<Year>(year).State = EntityState.Modified;
        }
    }
}

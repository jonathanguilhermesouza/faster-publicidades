using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Linq;
using System.Data.Entity;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class DayOfMonthRepository : IDayOfMonthRepository
    {
        private FasterTvIndoorDataContext _context;
        public DayOfMonthRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public void Create(DayOfMonth day)
        {
            _context.DayOfMonth.Add(day);
        }

        public void Delete(DayOfMonth day)
        {
            throw new NotImplementedException();
        }

        public List<DayOfMonth> GetAll()
        {
            return _context.DayOfMonth.ToList();
        }

        public DayOfMonth GetById(int id)
        {
            return _context.DayOfMonth
               .SingleOrDefault(x => x.IdDayOfMonth == id);
        }

        public void Update(DayOfMonth day)
        {
            _context.Entry<DayOfMonth>(day).State = EntityState.Modified;
        }
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;
using System;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using System.Data.Entity;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class HistoryEquipmentRepository : IHistoryEquipmentRepository
    {
        private FasterTvIndoorDataContext _context;
        public HistoryEquipmentRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public void Create(HistoryEquipment history)
        {
            _context
                .HistoryEquipment
                .Add(history);
        }

        public List<HistoryEquipment> GetAll()
        {
            return _context.
                HistoryEquipment
                .ToList();
        }

        public HistoryEquipment GetById(int id)
        {
            return _context
                .HistoryEquipment
                .SingleOrDefault(x => x.IdHistoryEquipment == id);
        }

        public List<HistoryEquipment> GetByRangeEquipment(int skip, int take, int id)
        {
            return _context
                .HistoryEquipment
                .Include("Video.Company")
                .Include("Video.Plan")
                .Where(HistoryEquipmentSpecs.GetHistoryEquipment(id))
                .OrderBy(x => x.IdHistoryEquipment).Skip((skip - 1) * take)
                .Take(take).ToList();
        }

        public List<HistoryEquipment> GetByRangeCompany(int skip, int take, int id)
        {
            return _context
                .HistoryEquipment
                .Include("Video.Company")
                .Include("Video.Plan")
                .Include("Equipment")
                .Where(HistoryEquipmentSpecs.GetHistoryCompany(id))
                .OrderByDescending(x => x.IdHistoryEquipment).Skip((skip - 1) * take)
                .Take(take).ToList();
        }

        public int GetCount(int id)
        {
            return _context.HistoryEquipment
                .Where(HistoryEquipmentSpecs.GetHistoryEquipment(id))
                .Count();
        }

        public int GetCountByCompany(int id)
        {
            return _context.HistoryEquipment
                .Where(HistoryEquipmentSpecs.GetHistoryCompany(id))
                .Count();
        }

        public void Update(HistoryEquipment history)
        {
            _context.Entry<HistoryEquipment>(history).State = EntityState.Modified;
        }
    }
}

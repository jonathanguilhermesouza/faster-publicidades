using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class PlanRepository : IPlanRepository
    {
        private FasterTvIndoorDataContext _context;
        public PlanRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<Plan> GetAll()
        {
            return _context.Plan.ToList();
        }

        public List<Plan> GetByRange(int skip, int take, string word)
        {
            return _context.Plan
                .Where(PlanSpecs.GetPlan(word))
                .OrderBy(x => x.ValueEquipmentMain)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public Plan GetById(int id)
        {
            return _context.Plan
                .SingleOrDefault(x => x.IdPlan == id);
        }

        public void Create(Plan plan)
        {
            _context.Plan.Add(plan);
        }

        public void Update(Plan plan)
        {
            _context.Entry<Plan>(plan).State = EntityState.Modified;
        }

        public int GetCount(string word)
        {
            return _context.Plan.Where(PlanSpecs.GetPlan(word)).Count();
        }

        public void Delete(Plan plan)
        {
            throw new System.NotImplementedException();
        }
    }
}

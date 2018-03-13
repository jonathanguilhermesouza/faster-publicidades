using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class ContractRepository : IContractRepository
    {
        private FasterTvIndoorDataContext _context;
        public ContractRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<Contract> GetAll()
        {
            return _context.Contract.Include("Company").ToList();
        }

        public List<Contract> GetByRange(int skip, int take, string word, EStatusContract statusContract)
        {
            return _context.Contract.Include("Company").Where(ContractSpecs.GetSearchContract(word, statusContract))
                .OrderBy(x => x.IdContract).Skip((skip - 1) * take).Take(take).ToList();
        }

        public Contract GetById(int id)
        {
            return _context.Contract.Include("Company").Include("DayOfMonth").SingleOrDefault(x => x.IdContract == id);
        }

        public void Create(Contract contract)
        {
            _context.Contract.Add(contract);
        }

        public void Update(Contract contract)
        {
            _context.Entry<Contract>(contract).State = EntityState.Modified;
        }

        public void Cancel(Contract contract)
        {
            _context.Entry<Contract>(contract).State = EntityState.Modified;
        }

        public int GetCount(string word, EStatusContract statusContract)
        {
            return _context.Contract.Where(ContractSpecs.GetSearchContract(word, statusContract)).Count();
        }
    }
}

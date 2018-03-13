using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Linq;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class CompanyRepository : ICompanyRepository
    {
        private FasterTvIndoorDataContext _context;
        public CompanyRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public int GetCount(string word, EStatusCompany status)
        {
            return _context.Company.Where(CompanySpecs.GetCompany(word, status)).Count();
        }

        public List<Company> GetByRange(int skip, int take, string word, EStatusCompany status)
        {
            return _context.Company
                .Include("ListAddressCompany")
                .Include("ListPhonesCompany")
                .Where(CompanySpecs.GetCompany(word, status))
                .OrderBy(x => x.IdCompany).Skip((skip - 1) * take).Take(take).ToList();
        }

        public Company GetById(int id)
        {
            //return _context.Company.Find(id);
            return _context.Company.Include("ListPhonesCompany")
                .Include("ListAddressCompany")
                .SingleOrDefault(x => x.IdCompany == id);
        }
        
        public void Create(Company company)
        {
            _context.Company.Add(company);
        }

        public void Update(Company company)
        {
            _context.Entry<Company>(company).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Company company)
        {
            _context.Entry<Company>(company).State = System.Data.Entity.EntityState.Modified;
           
        }

    }
}

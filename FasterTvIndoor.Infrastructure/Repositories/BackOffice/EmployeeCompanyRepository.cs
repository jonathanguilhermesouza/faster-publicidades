using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.BackOffice.Entities;
using FasterTvIndoor.Domain.BackOffice.Repositories;
using FasterTvIndoor.Domain.BackOffice.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.BackOffice
{
    public class EmployeeCompanyRepository : IEmployeeCompanyRepository
    {
        private FasterTvIndoorDataContext _context;
        public EmployeeCompanyRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public int GetCount(string word, EStatusUser status)
        {
            return _context.EmployeeCompany.Where(EmployeeCompanySpecs.GetEmployeeCompany(word,status)).Count();
        }

        public List<EmployeeCompany> GetByRange(int skip, string word, EStatusUser status)
        {
            int take = 12;

            return _context.EmployeeCompany
                .Include("Company")
                .Include("User")
                .Include("User.ProfileUser")
                .Include("SectorCompany")
                .Where(EmployeeCompanySpecs.GetEmployeeCompany(word,status))
                .OrderBy(x => x.IdCompany).Skip((skip - 1) * take).Take(take).ToList();
        }

        public EmployeeCompany GetById(int id)
        {
            return _context.EmployeeCompany
                .Include("User")
                .Include("SectorCompany")
                .Include("User.ProfileUser")
                .Include("User.ListAddressUser")
                .Include("User.ListPhoneUser")
                .Include("Company")
                .SingleOrDefault(x => x.IdEmployeeCompany == id);
        }

        public EmployeeCompany GetByEmail(string email)
        {
            return _context.EmployeeCompany
                .Include("User")
                .Include("SectorCompany")
                .Include("User.ProfileUser")
                .Include("User.ListAddressUser")
                .Include("User.ListPhoneUser")
                .Include("Company")
                .SingleOrDefault(x => x.User.Email == email);
        }

        public void Create(EmployeeCompany employee)
        {
            _context.EmployeeCompany.Add(employee);
        }

        public void Update(EmployeeCompany employee)
        {
            _context.Entry<EmployeeCompany>(employee).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(EmployeeCompany employee)
        {
            _context.EmployeeCompany.Remove(employee);
        }
    }
}

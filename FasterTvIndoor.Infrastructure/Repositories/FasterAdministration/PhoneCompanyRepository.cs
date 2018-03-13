using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class PhoneCompanyRepository : IPhoneCompanyRepository
    {
        private FasterTvIndoorDataContext _context;
        public PhoneCompanyRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public List<PhoneCompany> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhoneCompany GetById(int id)
        {
            return _context.PhoneCompany.Include("Company").SingleOrDefault(x => x.IdPhoneCompany == id);
        }

        public void Update(PhoneCompany phone)
        {
            _context.Entry<PhoneCompany>(phone).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(PhoneCompany phone)
        {
            _context.PhoneCompany.Remove(phone);
        }

        public void Create(PhoneCompany phone)
        {
            _context.PhoneCompany.Add(phone);
        }
    }
}

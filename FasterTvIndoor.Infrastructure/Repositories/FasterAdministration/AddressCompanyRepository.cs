using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class AddressCompanyRepository : IAddressCompanyRepository
    {
        private FasterTvIndoorDataContext _context;
        public AddressCompanyRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public List<AddressCompany> GetAll()
        {
            throw new NotImplementedException();
        }

        public AddressCompany GetById(int id)
        {
            return _context.AddressCompany.Include("Company").SingleOrDefault(x => x.IdAddressCompany == id);
        }

        public void Update(AddressCompany address)
        {
            _context.Entry<AddressCompany>(address).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(AddressCompany address)
        {
            _context.AddressCompany.Remove(address);
        }
    }
}

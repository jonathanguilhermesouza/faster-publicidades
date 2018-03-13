using FasterTvIndoor.Domain.Client.Entities;
using FasterTvIndoor.Domain.Client.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.Client
{
    public class AddressUserRepository : IAddressUserRepository
    {
        private FasterTvIndoorDataContext _context;
        public AddressUserRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public List<AddressUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public AddressUser GetById(int id)
        {
            return _context.AddressUser.Include("User").SingleOrDefault(x => x.IdAddressUser == id);
        }

        public void Create(AddressUser address)
        {
            _context.AddressUser.Add(address);
        }

        public void Update(AddressUser address)
        {
            _context.Entry<AddressUser>(address).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(AddressUser address)
        {
            _context.AddressUser.Remove(address);
        }
    }
}

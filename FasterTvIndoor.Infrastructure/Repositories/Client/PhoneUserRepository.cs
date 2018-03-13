using FasterTvIndoor.Domain.Client.Repositories;
using FasterTvIndoor.Domain.Entities;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.Client
{
    public class PhoneUserRepository : IPhoneUserRepository
    {
        private FasterTvIndoorDataContext _context;
        public PhoneUserRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<PhoneUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhoneUser GetById(int id)
        {
            return _context.PhoneUser.Include("User").SingleOrDefault(x => x.IdPhoneUser == id);
        }

        public void Update(PhoneUser phone)
        {
            _context.Entry<PhoneUser>(phone).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(PhoneUser phone)
        {
            _context.PhoneUser.Remove(phone);
        }

        public void Create(PhoneUser phone)
        {
            _context.PhoneUser.Add(phone);
        }
    }
}

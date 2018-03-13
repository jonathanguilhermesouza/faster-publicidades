using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class ProfileUserRepository : IProfileUserRepository
    {
        private FasterTvIndoorDataContext _context;
        public ProfileUserRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public List<ProfileUser> GetAll()
        {
            return _context.ProfileUser.ToList();
        }

        public List<ProfileUser> GetByRange(int skip, int take)
        {
            return _context.ProfileUser.OrderBy(x => x.Profile).Skip((skip - 1) * take).Take(take).ToList();
        }

        public ProfileUser GetById(int id)
        {
            return _context.ProfileUser.Find(id);
        }

        public void Create(ProfileUser profile)
        {
            _context.ProfileUser.Add(profile);
        }

        public void Update(ProfileUser profile)
        {
            _context.Entry<ProfileUser>(profile).State = EntityState.Modified;
        }

        public void Delete(ProfileUser profile)
        {
            _context.ProfileUser.Remove(profile);
        }

        public int GetCount()
        {
            return _context.ProfileUser.Count();
        }
    }
}

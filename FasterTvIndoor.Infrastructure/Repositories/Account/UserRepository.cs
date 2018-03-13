using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.Account.Repositories;
using FasterTvIndoor.Domain.Account.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.Account
{
    public class UserRepository : IUserRepository
    {
        private FasterTvIndoorDataContext _context;

        public UserRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public void Register(User user)
        {
            _context.User.Add(user);
        }

        public User Authenticate(string username, string password)
        {
            return _context.User
                .Include("ProfileUser")
                .Where(UserSpecs.AuthenticateUser(username, password))
                .FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _context.User
                .Include("ProfileUser")
                .Where(UserSpecs.GetByEmail(email))
                .FirstOrDefault();
        }

        public List<User> List()
        {
            return _context.User.OrderBy(a => a.Email).ToList();
        }

        public List<User> GetUserAdminByCompany(int idCompany)
        {
            return _context.User
                .Where(UserSpecs.GetUserAdminByCompany(idCompany))
                .ToList();
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
        }

        public User Get(int id)
        {
            return _context.User.SingleOrDefault(x => x.IdUser == id);
        }

        public bool CheckUserByEmail(string email)
        {
            var user = _context.User.Where(UserSpecs.CheckUserByEmail(email)).Count();

            if (user > 0)
                return true;

            return false;
        }

        public bool CheckUserByNickname(string nickname)
        {
            var user = _context.User.Where(UserSpecs.CheckUserByNickname(nickname)).Count();

            if (user > 0)
                return true;

            return false;
        }
    }
}

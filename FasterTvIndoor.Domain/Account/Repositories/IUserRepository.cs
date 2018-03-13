using FasterTvIndoor.Domain.Account.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.Account.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);
        void Update(User user);
        User Authenticate(string username, string password);
        User GetByEmail(string email);
        bool CheckUserByEmail(string email);
        bool CheckUserByNickname(string nickname);
        User Get(int id);
        List<User> List();
        List<User> GetUserAdminByCompany(int idCompany);
    }
}

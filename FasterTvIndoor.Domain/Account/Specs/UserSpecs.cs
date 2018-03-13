using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.SharedKernel.Helpers;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.Account.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> AuthenticateUser(string username, string password)
        {
            string encriptedPassword = StringHelper.Encrypt(password);
            return x => (x.Email == username || x.NickName == username) && x.Password == encriptedPassword;
        }

        public static Expression<Func<User, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }

        public static Expression<Func<User, bool>> GetUserAdminByCompany(int idCompany)
        {
            return null;
        }

        public static Expression<Func<User, bool>> CheckUserByEmail(string email)
        {
            return x => x.Email == email;
        }

        public static Expression<Func<User, bool>> CheckUserByNickname(string nickname)
        {
            return x => x.NickName == nickname;
        }
    }
}

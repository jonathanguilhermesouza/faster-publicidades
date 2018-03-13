using FasterTvIndoor.Domain.Account.Commands.UserCommands;
using FasterTvIndoor.Domain.Account.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.Account.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);
        User Authenticate(string username, string password);
        User GetByEmail(string email);
        List<User> GetUserAdminByCompany(int idCompany);
        User Update(UpdateUserCommand command);
        List<User> List();
    }
}

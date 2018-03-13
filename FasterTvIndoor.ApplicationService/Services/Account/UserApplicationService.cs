using FasterTvIndoor.Domain.Account.Commands.UserCommands;
using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.Account.Repositories;
using FasterTvIndoor.Domain.Account.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.Account
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }
        
        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Email, command.Name, command.LastName, command.Password, command.NickName);

            var searchEmail = _repository.CheckUserByEmail(command.Email);
            var searchNickname = _repository.CheckUserByNickname(command.NickName);

            user.Register(searchEmail, searchNickname);
            _repository.Register(user);

            if (Commit())
                return user;
            
            return null;
        }

        public User Authenticate(string username, string password)
        {
            return _repository.Authenticate(username, password);
        }

        public List<User> List()
        {
            return _repository.List();
        }

        public List<User> GetUserAdminByCompany(int idCompany)
        {
            return _repository.GetUserAdminByCompany(idCompany);
        }


        public User Update(UpdateUserCommand command)
        {
            var user = _repository.Get(command.IdUser);
            user.Update(command);
            _repository.Update(user);

            if (Commit())
                return user;

            return null;
        }

        public User GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
    }
}

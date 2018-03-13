using FasterTvIndoor.Domain.Account.Entities;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using FasterTvIndoor.Domain.FasterAdministration.Commands.ProfileUserCommands;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class ProfileUser
    {
        protected ProfileUser() { }
        public ProfileUser(int idProfileUser,string profile)
        {
            this.IdProfileUser = idProfileUser;
            this.Profile = profile;
        }
        public ProfileUser(string profile)
        {
            this.IdProfileUser = 1;
            this.Profile = profile;
        }
        public ProfileUser(string profile, List<User> listUser)
        {
            this.Profile = profile;
            this.ListUser = listUser;
        }
        public int IdProfileUser { get; private set; }
        public string Profile { get; private set; }
        public ICollection<User> ListUser { get; private set; }

        public void Register()
        {
            if (!this.CreateProfileUserScopeIsValid())
                return;

        }

        public void UpdateProfile(string profile)
        {
            if (!this.UpdateProfileUserScopeisValid(profile))
                return;

            this.Profile = profile;
        }

        public void DeleteProfile(DeleteProfileUserCommand command)
        {
            this.IdProfileUser = command.ProfileId;
        }
    }
}

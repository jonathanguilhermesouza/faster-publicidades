
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ProfileUserCommands
{
    public class UpdateProfileUserCompanyCommand
    {
        public int ProfileId { get; set; }
        public string Profile { get; set; }
        public UpdateProfileUserCompanyCommand(int idProfileUser, string profile)
        {
            this.ProfileId = idProfileUser;
            this.Profile = profile;
        }
    }
}

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ProfileUserCommands
{
    public class CreateProfileUserCommand
    {
        public string Profile { get; set; }


        public CreateProfileUserCommand(string profile)
        {
            this.Profile = profile;
        }
    }
}

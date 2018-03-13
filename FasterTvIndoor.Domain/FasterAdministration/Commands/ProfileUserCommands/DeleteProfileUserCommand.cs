
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ProfileUserCommands
{
    public class DeleteProfileUserCommand
    {
        public int ProfileId { get; set; }

        public DeleteProfileUserCommand(int id)
        {
            this.ProfileId = id;
        }
    }
}

namespace FasterTvIndoor.Domain.Client.Commands.PhoneUserCommands
{
    public class DeletePhoneUserCommand
    {
        public DeletePhoneUserCommand(int idPhoneUser)
        {
            this.IdPhoneUser = idPhoneUser;
        }
        public int IdPhoneUser { get; set; }
    }
}

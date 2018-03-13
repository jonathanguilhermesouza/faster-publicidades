namespace FasterTvIndoor.Domain.Client.Commands.PhoneUserCommands
{
    public class UpdatePhoneUserCommand
    {
        public UpdatePhoneUserCommand(int idPhoneUser, string number)
        {
            this.IdPhoneUser = idPhoneUser;
            this.Number = number;
        }
        public int IdPhoneUser { get; set; }
        public string Number { get; set; }
    }
}

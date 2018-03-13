namespace FasterTvIndoor.Domain.Client.Commands.PhoneUserCommands
{
    public class CreatePhoneUserCommand
    {
        public CreatePhoneUserCommand(string number, int idUser)
        {
            this.Number = number;
            this.IdUser = idUser;
        }
        public string Number { get; set; }
        public int IdUser { get; set; }
    }
}

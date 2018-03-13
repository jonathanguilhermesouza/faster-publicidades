namespace FasterTvIndoor.Domain.Client.Commands.AddressUserCommands
{
    public class DeleteAddressUserCommand
    {
        public DeleteAddressUserCommand(int idAddressUser)
        {
            this.IdAddressUser = idAddressUser;  
        }
        public int IdAddressUser { get; set; }
    }
}

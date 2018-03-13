
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.TimeVideoCoomands
{
    public class CreateTimeVideoCommand
    {
        public CreateTimeVideoCommand(int time)
        {
            this.Time = time;
        }
        public int IdTimeVideo { get; set; }
        public int Time { get; set; }
    }
}


namespace FasterTvIndoor.Domain.FasterAdministration.Commands.TimeVideoCoomands
{
    public class UpdateTimeVideoCommand
    {
        public UpdateTimeVideoCommand(int idTimeVideo, int time)
        {
            this.IdTimeVideo = idTimeVideo;
            this.Time = time;
        }
        public int IdTimeVideo { get; set; }
        public int Time { get; set; }
    }
}

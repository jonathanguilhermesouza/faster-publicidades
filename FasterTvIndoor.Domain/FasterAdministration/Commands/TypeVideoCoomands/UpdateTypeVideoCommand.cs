
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.TypeVideoCoomands
{
    public class UpdateTypeVideoCommand
    {
        public UpdateTypeVideoCommand(int idTypeVideo, string type)
        {
            this.IdTypeVideo = idTypeVideo;
            this.Type = type;
        }
        public int IdTypeVideo { get; set; }
        public string Type { get; private set; }
    }
}

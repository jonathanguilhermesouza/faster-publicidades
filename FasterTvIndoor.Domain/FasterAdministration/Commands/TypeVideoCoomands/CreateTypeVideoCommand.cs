
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.TypeVideoCoomands
{
    public class CreateTypeVideoCommand
    {
        public CreateTypeVideoCommand(string type)
        {
            this.Type = type;
        }
        public string Type { get; private set; }
    }
}

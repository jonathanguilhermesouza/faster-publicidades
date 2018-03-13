
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.CategoryVideoCoomands
{
    public class UpdateCategoryVideoCommand
    {
        public UpdateCategoryVideoCommand(int idCategoryVideo, string category)
        {
            this.IdCategoryVideo = idCategoryVideo;
            this.Category = category;
        }
        public int IdCategoryVideo { get; set; }
        public string Category { get; set; }
    }
}

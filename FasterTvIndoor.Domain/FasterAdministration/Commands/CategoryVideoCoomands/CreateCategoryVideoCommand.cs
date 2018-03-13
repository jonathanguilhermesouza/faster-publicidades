
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.CategoryVideoCoomands
{
    public class CreateCategoryVideoCommand
    {
        public CreateCategoryVideoCommand(string category)
        {
            this.Category = category;
        }
        public string Category { get; set; }
    }
}

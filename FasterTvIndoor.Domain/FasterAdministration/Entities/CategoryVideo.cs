using FasterTvIndoor.Domain.FasterAdministration.Commands.CategoryVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class CategoryVideo
    {
        public CategoryVideo(){}
        public CategoryVideo(string category)
        {
            this.Category = category;
        }
        public int IdCategoryVideo { get; set; }
        public string Category { get; set; }
        public ICollection<Video> ListVideo { get; set; }

        public void Create()
        {
            if (!this.CreateCategoryVideoScopeIsValid())
                return;
        }

        public void Update(UpdateCategoryVideoCommand command)
        {
            if (!this.UpdateCategoryVideoScopeIsValid(command))
                return;

            this.Category = command.Category;
        }
    }
}

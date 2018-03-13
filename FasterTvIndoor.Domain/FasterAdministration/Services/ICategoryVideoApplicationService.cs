using FasterTvIndoor.Domain.FasterAdministration.Commands.CategoryVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface ICategoryVideoApplicationService
    {
        List<CategoryVideo> GetAll();
        List<CategoryVideo> GetByRange(int skip, int take, string word);
        CategoryVideo GetById(int id);
        CategoryVideo Create(CreateCategoryVideoCommand command);
        CategoryVideo Update(UpdateCategoryVideoCommand command);
        CategoryVideo Delete(/*DeleteSectorCompanyCommand command*/);
        int GetCount(string word);
    }
}

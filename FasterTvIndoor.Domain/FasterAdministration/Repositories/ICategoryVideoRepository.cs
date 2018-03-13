using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface ICategoryVideoRepository
    {
        List<CategoryVideo> GetAll();
        List<CategoryVideo> GetByRange(int skip, int take, string word);
        CategoryVideo GetById(int id);
        void Create(CategoryVideo category);
        void Update(CategoryVideo category);
        int GetCount(string word);
    }
}

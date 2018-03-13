using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface ITypeVideoRepository
    {
        List<TypeVideo> GetAll();
        List<TypeVideo> GetByRange(int skip, int take, string word);
        TypeVideo GetById(int id);
        void Create(TypeVideo type);
        void Update(TypeVideo type);
        int GetCount(string word);
    }
}

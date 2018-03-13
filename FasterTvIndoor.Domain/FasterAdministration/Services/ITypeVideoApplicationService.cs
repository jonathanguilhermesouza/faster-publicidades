using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface ITypeVideoApplicationService
    {
        List<TypeVideo> GetAll();
        List<TypeVideo> GetByRange(int skip, int take, string word);
        TypeVideo GetById(int id);
        TypeVideo Create(CreateTypeVideoCommand command);
        TypeVideo Update(UpdateTypeVideoCommand command);
        TypeVideo Delete(/*DeleteTypeVideoCommand command*/);
        int GetCount(string word);
    }
}

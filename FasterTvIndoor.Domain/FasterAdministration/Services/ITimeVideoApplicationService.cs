using FasterTvIndoor.Domain.FasterAdministration.Commands.TimeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface ITimeVideoApplicationService
    {
        List<TimeVideo> GetAll();
        List<TimeVideo> GetByRange(int skip, int take);
        TimeVideo GetById(int id);
        TimeVideo Create(CreateTimeVideoCommand command);
        TimeVideo Update(UpdateTimeVideoCommand command);
        TimeVideo Delete(/*DeleteTimeVideoCommand command*/);
        int GetCount();
    }
}

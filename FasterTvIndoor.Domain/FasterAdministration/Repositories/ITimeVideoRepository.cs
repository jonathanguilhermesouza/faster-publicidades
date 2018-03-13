using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface ITimeVideoRepository
    {
        List<TimeVideo> GetAll();
        List<TimeVideo> GetByRange(int skip, int take);
        TimeVideo GetById(int id);
        void Create(TimeVideo timeVideo);
        void Update(TimeVideo timeVideo);
        void Delete(TimeVideo timeVideo);
        int GetCount();
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IVideoRepository
    {
        List<Video> GetAll();
        List<Video> GetByRange(int skip, int take, string word, EStatusVideo status);
        List<Video> GetByRangeCompany(int skip, int take, int id, EStatusVideo status);
        Video GetById(int id);
        void Delete(Video video);
        void Create(Video video);
        void Update(Video video);
        int GetCount(string word, EStatusVideo status);
        int GetCountCompany(int id, EStatusVideo status);
    }
}

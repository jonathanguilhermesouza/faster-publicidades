using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IVideoApplicationService
    {
        List<Video> GetAll();
        List<Video> GetByRange(int skip, int take, string word, EStatusVideo status);
        List<Video> GetByRangeCompany(int skip, int take, int id, EStatusVideo status);
        Video GetById(int id);
        Video Create(CreateVideoCommand command);
        Video Update(UpdateVideoCommand command);
        Video Delete(DeleteVideoCommand command);
        int GetCount(string word, EStatusVideo status);
        int GetCountCompany(int id, EStatusVideo status);
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IVideoEquipmentApplicationService
    {
        List<VideoEquipment> GetAll();
        VideoEquipment GetIdVideoEquipment(int equipment, int video);
        List<VideoEquipment> GetByRange(int skip, int take, string word);
        List<VideoEquipment> GetByRange(int skip, int take, int id);
        List<VideoEquipment> GetByRangeCompany(int skip, int take, int id);
        VideoEquipment GetById(int id);
        List<VideoEquipment> GetByIdEquipment(int id);
        VideoEquipment Create(CreateVideoEquipmentCommand command);
        VideoEquipment Update(UpdateVideoEquipmentCommand command);
        void UpdateStatusListVideo();
        VideoEquipment Delete(int idEquipment,int idVideo, int controlLoan);
        int GetCount(string word);
        int GetVideoCountByCompany(int id);
        decimal GetTotalVideoByEquipment(int idVideo);
        int GetVideoCountByEquipment(int idVideo);
    }
}

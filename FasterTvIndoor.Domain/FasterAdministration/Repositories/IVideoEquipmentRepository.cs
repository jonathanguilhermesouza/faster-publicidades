using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IVideoEquipmentRepository
    {
        List<VideoEquipment> GetAll();
        VideoEquipment GetIdVideoEquipment(int equipment, int video);
        List<VideoEquipment> GetAllByVideo(int video);
        List<VideoEquipment> GetByRange(int skip, int take, string word);
        List<VideoEquipment> GetByRange(int skip, int take, int id);
        List<VideoEquipment> GetByRangeCompany(int skip, int take, int id);
        VideoEquipment GetById(int id);
        List<VideoEquipment> GetByStatus(EStatusVideoEquipment status);
        VideoEquipment GetById(int idEquipment, int idVideo, int idControlLoan);
        List<VideoEquipment> GetByIdEquipment(int id);
        void Create(VideoEquipment videoEquipment);
        void Update(VideoEquipment videoEquipment);
        void Delete(VideoEquipment videoEquipment);
        void Delete(ICollection<VideoEquipment> listVideoEquipment);
        int GetCount(string word);
        int GetCount(string word,int idCompany);
        int GetVideoCountByCompany(int id);
        void UpdateStatusListVideo(ICollection<VideoEquipment> listVideoEquipment);
        decimal GetTotalVideoByEquipment(int idVideo);
        int GetVideoCountByEquipment(int idVideo);
    }
}

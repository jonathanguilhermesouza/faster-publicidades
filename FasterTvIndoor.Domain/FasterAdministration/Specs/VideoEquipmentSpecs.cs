using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public static class VideoEquipmentSpecs
    {
        public static Expression<Func<VideoEquipment, bool>> GetVideoEquipment(string word)
        {

            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdVideoEquipment.Equals(null) && x.Status == EStatusVideoEquipment.Ativo;

            return x => (x.Video.IdVideo.Equals(word) || x.Equipment.IdEquipment.Equals(word)) && x.Status == EStatusVideoEquipment.Ativo;
        }

        public static Expression<Func<VideoEquipment, bool>> GetIdVideoEquipment(int equipment, int video)
        {
            return x => (x.IdEquipment == equipment && x.IdVideo == video) && x.Status == EStatusVideoEquipment.Ativo;
        }

        public static Expression<Func<VideoEquipment, bool>> GetVideoByCompany(int company)
        {
            return x => x.ControlLoan.IdCompany == company && x.Status == EStatusVideoEquipment.Ativo && x.Video.Status == EStatusVideo.Ativo;
        }

        public static Expression<Func<VideoEquipment, bool>> GetByVideo(int video)
        {
            return x => x.IdVideo == video && x.Status == EStatusVideoEquipment.Ativo;
        }

        public static Expression<Func<VideoEquipment, bool>> GetVideoEquipmentByCompany(int idCompany)
        {
            return x => x.ControlLoan.IdCompany == idCompany;
        }

        public static Expression<Func<VideoEquipment, bool>> GetTotalByEquipment(int idVideo)
        {
            return x => x.IdVideo == idVideo && x.Video.Status == EStatusVideo.Ativo && x.Status == EStatusVideoEquipment.Ativo;
        }
        
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class VideoEquipment
    {
        public VideoEquipment() { }

        public VideoEquipment(int idVideo, int idEquipment, int idControlLoan)
        {
            this.IdVideo = idVideo;
            this.IdEquipment = idEquipment;
            this.IdControlLoan = idControlLoan;
            this.Status = EStatusVideoEquipment.Ativo;
        }
        public int IdVideoEquipment { get; private set; }
        public int IdVideo { get; set; }
        public int IdEquipment { get; set; }
        //public DateTime DateUpdate { get; set; }
        public int IdControlLoan { get; set; }
        public int Order { get; set; }
        public DateTime DateRegister { get; set; }
        public EStatusVideoEquipment Status { get; set; }
        public ControlLoan ControlLoan { get; set; }
        public Equipment Equipment { get; private set; }
        public Video Video { get; private set; }

        public void Create(VideoEquipment videoEquipment)
        {
            this.Status = EStatusVideoEquipment.Ativo;
            this.DateRegister = DateTime.Now;
        }

        public void Update(UpdateVideoEquipmentCommand command)
        {
            this.IdEquipment = command.IdEquipment;
            this.IdVideo = command.IdVideo;
            this.IdControlLoan = command.IdControlLoan;
            this.Status = command.Status;
            //this.DateUpdate = DateTime.Now;
        }

        public ICollection<VideoEquipment> UpdateStatusListVideo(ICollection<VideoEquipment> listVideoEquipment)
        {
            List<VideoEquipment> listVideoEquipmentUpdate = new List<VideoEquipment>();

            foreach (var item in listVideoEquipment)
            {
                item.Video.Status = EStatusVideo.Inativo;
                item.Status = EStatusVideoEquipment.Inativo;
                listVideoEquipmentUpdate.Add(item);
            }

            return listVideoEquipmentUpdate;
        }

        public void Delete(VideoEquipment command)
        {
            this.Status = EStatusVideoEquipment.Inativo;
        }

        public ICollection<VideoEquipment> Delete(ICollection<VideoEquipment> listVideoEquipment)
        {
            foreach (var videoEquipment in listVideoEquipment)
            {
                videoEquipment.Status = EStatusVideoEquipment.Inativo;

            }

            return listVideoEquipment;
        }
    }
}

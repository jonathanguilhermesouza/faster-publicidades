using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.VideoEquipmentCommands
{
    public class CreateVideoEquipmentCommand
    {
        //public CreateVideoEquipmentCommand(int idVideo, int idEquipment)
        //{
        //    this.IdVideo = idVideo;
        //    this.IdEquipment = idEquipment;
        //}
        public CreateVideoEquipmentCommand(int idEquipment, int idVideo, int idControlLoan)
        {
            this.IdEquipment = idEquipment;
            this.IdVideo = idVideo;
            this.IdControlLoan = idControlLoan;
        }
        public int IdVideo { get; set; }
        public int IdEquipment { get; set; }
        public int IdControlLoan { get; set; }
        public List<VideoEquipment> ListVideoEquipment { get; set; }
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.VideoEquipmentCommands
{
    public class DeleteVideoEquipmentCommand
    {
        public DeleteVideoEquipmentCommand(int idVideoEquipment, int idVideo, int idEquipment, int idControlLoan)
        {
            this.IdVideoEquipment = idVideoEquipment;
            this.IdVideo = idVideo;
            this.IdEquipment = idEquipment;
            this.IdControlLoan = idControlLoan;
        }
        public int IdVideoEquipment { get; private set; }
        public int IdVideo { get; private set; }
        public int IdEquipment { get; private set; }
        public int IdControlLoan { get; set; }
        public EStatusVideoEquipment Status { get; set; }
    }
}

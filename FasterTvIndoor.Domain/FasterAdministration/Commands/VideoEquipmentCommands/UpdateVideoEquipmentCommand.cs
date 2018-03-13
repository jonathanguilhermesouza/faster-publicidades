
using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.VideoEquipmentCommands
{
    public class UpdateVideoEquipmentCommand
    {
        public UpdateVideoEquipmentCommand(int idVideoEquipment,int idVideo, int idEquipment, int idControlLoan)
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

using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.HistoryEquipmentCommands
{
    public class CreateHistoryEquipmentCommand
    {
        public CreateHistoryEquipmentCommand(int idVideo, int idEquipment, int idCompany, decimal value, string plan)
        {
            this.IdVideo = idVideo;
            this.IdEquipment = idEquipment;
            this.DateOfRegister = DateTime.Now;
            this.Action = EAction.Inclusão;
            this.Value = value;
            this.IdCompany = idCompany;
            this.Plan = plan;
        }

        public int IdVideo { get; set; }
        public int IdEquipment { get; set; }
        public decimal Value { get; set; }
        public int IdCompany { get; set; }
        public string  Plan { get; set; }
        public DateTime DateOfRegister { get; set; }
        public EAction Action { get; set; }
    }
}

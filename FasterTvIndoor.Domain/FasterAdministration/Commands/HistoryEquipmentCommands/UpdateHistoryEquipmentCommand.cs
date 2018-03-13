using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.HistoryEquipmentCommands
{
    public class UpdateHistoryEquipmentCommand
    {
        public UpdateHistoryEquipmentCommand(int idHistoryEquipment, int idVideo, int idEquipment, int idCompany, decimal value, string plan)
        {
            this.IdHistoryEquipment = IdHistoryEquipment;
            this.IdVideo = idVideo;
            this.IdEquipment = idEquipment;
            this.DateOfRegister = DateTime.Now;
            this.Action = EAction.Atualização;
            this.Value = value;
            this.IdCompany = idCompany;
            this.Plan = plan;
        }

        public int IdHistoryEquipment { get; set; }
        public int IdVideo { get; set; }
        public int IdEquipment { get; set; }
        public decimal Value { get; set; }
        public int IdCompany { get; set; }
        public DateTime DateOfRegister { get; set; }
        public EAction Action { get; set; }
        public string Plan { get; set; }
    }
}

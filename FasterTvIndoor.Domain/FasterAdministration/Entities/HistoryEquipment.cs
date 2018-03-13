using FasterTvIndoor.Domain.FasterAdministration.Commands.HistoryEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class HistoryEquipment
    {
        public HistoryEquipment() { }
        public HistoryEquipment(int idVideo, int idEquipment, int idCompany,string plan, EAction action, decimal value)
        {
            this.IdVideo = idVideo;
            this.IdEquipment = idEquipment;
            this.DateOfRegister = DateTime.Now;
            this.Action = action;
            this.Value = value;
            this.IdCompany = idCompany;
            this.Plan = plan;
        }
        public int IdHistoryEquipment { get; set; }
        public int IdVideo { get; set; }
        public int IdEquipment { get; set; }
        public int IdCompany { get; set; }
        public decimal Value { get; set; }
        public string Plan { get; set; }
        public DateTime DateOfRegister { get; set; }
        public EAction Action { get; set; }
        public Video Video { get; set; }
        public Equipment Equipment { get; set; }
        public Company Company { get; set; }

        public void Create()
        {

        }

        public void Update(UpdateHistoryEquipmentCommand command)
        {
            this.IdVideo = command.IdVideo;
            this.IdEquipment = command.IdEquipment;
            this.DateOfRegister = command.DateOfRegister;
            this.Action = command.Action;
            this.Value = command.Value;
        }
    }
}

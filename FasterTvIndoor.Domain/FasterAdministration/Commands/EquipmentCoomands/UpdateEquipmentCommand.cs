using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.EquipmentCoomands
{
    public class UpdateEquipmentCommand
    {
        public UpdateEquipmentCommand(int idEquipment, int idTypeEquipment, string description, string model, string serialNumber, DateTime dateBuy, string patrimony, EStatusEquipment statusEquipment)
        {
            this.IdEquipment = idEquipment;
            this.IdTypeEquipment = idTypeEquipment;
            this.Description = description;
            this.Model = model;
            this.SerialNumber = serialNumber;
            this.DateBuy = dateBuy;
            this.Patrimony = patrimony;
            this.StatusEquipment = statusEquipment;
        }
        public int IdEquipment { get; private set; }
        public int IdTypeEquipment { get; set; }
        public EStatusEquipment StatusEquipment { get; set; }
        public string Description { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime DateBuy { get; private set; }
        public string Patrimony { get; private set; }
    }
}

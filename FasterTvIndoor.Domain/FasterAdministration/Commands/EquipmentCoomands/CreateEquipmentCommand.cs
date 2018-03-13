using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.EquipmentCoomands
{
    public class CreateEquipmentCommand
    {
        public CreateEquipmentCommand(int idTypeEquipment,string description, string model, string serialNumber, DateTime dateBuy, string patrimony)
        {
            this.IdTypeEquipment = idTypeEquipment;
            this.Description = description;
            this.Model = model;
            this.SerialNumber = serialNumber;
            this.DateBuy = dateBuy;
            this.Patrimony = patrimony;
        }
        public int IdTypeEquipment { get; set; }
        public string Description { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime DateBuy { get; private set; }
        public string Patrimony { get; private set; }    
    }
}

using System;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using FasterTvIndoor.Domain.FasterAdministration.Commands.EquipmentCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class Equipment
    {
        public Equipment(){}
        public Equipment(int idEquipment, int idTypeEquipment, string description, string model, string serialNumber, DateTime dateBuy, string patrimony/*, ICollection<Video> listVideo*/)
        {
            this.IdEquipment = idEquipment;
            this.IdTypeEquipment = idTypeEquipment;
            this.Description = description;
            this.Model = model;
            this.SerialNumber = serialNumber;
            this.DateBuy = dateBuy;
            this.Patrimony = patrimony;
            //this.ListVideo = listVideo;
            this.StatusEquipment = EStatusEquipment.Disponível;
        }
        public Equipment(int idTypeEquipment, string description, string model, string serialNumber, DateTime dateBuy, string patrimony/*, ICollection<Video> listVideo*/)
        {
            this.IdTypeEquipment = idTypeEquipment;
            this.Description = description;
            this.Model = model;
            this.SerialNumber = serialNumber;
            this.DateBuy = dateBuy;
            this.Patrimony = patrimony;
            //this.ListVideo = listVideo;
        }
        public int IdEquipment { get; private set; }
        public int IdTypeEquipment { get; set; }
        public string Description { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime DateBuy { get; private set; }
        public string Patrimony { get; private set; }
        public TypeEquipment TypeEquipment { get; set; }
        public EStatusEquipment StatusEquipment { get; private set; }
        public ICollection<ControlLoan> ListControlLoan { get; private set; }
        public ICollection<VideoEquipment> ListVideoEquipment { get; private set; }
        public ICollection<HistoryEquipment> ListHistoryEquipment { get; set; }

        public void Create()
        {
            if (!this.CreateEquipmentScopeIsValid())
                return;

            this.StatusEquipment = EStatusEquipment.Disponível;
        }

        public void Update(UpdateEquipmentCommand command, EStatusEquipment status)
        {
            if (!this.UpdateEquipmentScopeIsValid(command,status))
                return;

            this.IdTypeEquipment = command.IdTypeEquipment;
            this.Description = command.Description;
            this.Model = command.Model;
            this.SerialNumber = command.SerialNumber;
            this.DateBuy = command.DateBuy;
            this.Patrimony = command.Patrimony;
            this.StatusEquipment = command.StatusEquipment;

        }

        public void UpdateStatus(EStatusEquipment status)
        { 
            this.StatusEquipment = status;
        }

        public void Delete()
        {
            this.StatusEquipment = EStatusEquipment.Desabilitado;
        }

    }
}

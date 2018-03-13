using System;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Commands.ControlLoanCommands;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class ControlLoan
    {
        public ControlLoan(){}
        public ControlLoan(DateTime dateLocation, DateTime dateEndLocation, string note, int idCompany,int idEquipment)
        {
            this.DateLocation = dateLocation;
            this.DateEndLocation = dateEndLocation;
            this.Note = note;
            this.IdCompany = idCompany;
            this.IdEquipment = idEquipment;
            this.StatusControlLoan = EStatusControlLoan.Vigente;
        }
        public int IdControlLoan { get; private set; }
        public int IdCompany { get; set; }
        public int IdEquipment { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateLocation { get; private set; }
        public DateTime DateEndLocation { get; private set; }
        public string Note { get; set; }
        public virtual Company Company { get; private set; }
        public virtual Equipment Equipment { get; private set; }
        public ICollection<VideoEquipment> ListVideoEquipment { get; private set; }
        public EStatusControlLoan StatusControlLoan { get; set; }

        public void Create(CreateControlLoanCommand command)
        {
            if (!this.CreateControlLoantScopesIsValid())
                return;

        }

        public void Update(UpdateControlLoanCommand command,EStatusControlLoan status)
        {
            if (!this.UpdateControlLoantScopesIsValid(command, status))
                return;

            this.DateLocation = command.DateLocation;
            this.DateEndLocation = command.DateEndLocation;
            this.Note = command.Note;
            this.IdCompany = command.IdCompany;
            this.IdEquipment = command.IdEquipment;
            this.StatusControlLoan = command.StatusControlLoan;
        }

        public void Delete()
        {
            this.StatusControlLoan = EStatusControlLoan.Cancelado;
            this.DateEndLocation = DateTime.Now;
        }

    }
}

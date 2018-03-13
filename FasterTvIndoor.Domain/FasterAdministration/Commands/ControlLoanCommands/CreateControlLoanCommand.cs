using System;
using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ControlLoanCommands
{
    public class CreateControlLoanCommand
    {
        public CreateControlLoanCommand(DateTime dateLocation, DateTime dateEndLocation, string note, int idCompany, int idEquipment)
        {
            this.DateLocation = dateLocation;
            this.DateEndLocation = dateEndLocation;
            this.Note = note;
            this.IdCompany = idCompany;
            this.IdEquipment = idEquipment;
            this.StatusControlLoan = EStatusControlLoan.Vigente;
        }
        
        public int IdCompany { get; set; }
        public int IdEquipment { get; set; }
        public DateTime DateLocation { get; private set; }
        public DateTime DateEndLocation { get; private set; }
        public string Note { get; set; }
        public EStatusControlLoan StatusControlLoan { get; set; }

    }
}

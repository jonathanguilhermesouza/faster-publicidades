using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ControlLoanCommands
{
    public class UpdateControlLoanCommand
    {
        public UpdateControlLoanCommand(int idControlLoan,DateTime dateLocation, DateTime dateEndLocation, string note,EStatusControlLoan statusControlLoan, int idCompany, int idEquipment)
        {
            this.IdControlLoan = idControlLoan;
            this.DateLocation = dateLocation;
            this.DateEndLocation = dateEndLocation;
            this.Note = note;
            this.IdCompany = idCompany;
            this.IdEquipment = idEquipment;
            this.StatusControlLoan = statusControlLoan;
        }

        public int IdControlLoan { get; set; }
        public int IdCompany { get; set; }
        public int IdEquipment { get; set; }
        public DateTime DateLocation { get; private set; }
        public DateTime DateEndLocation { get; private set; }
        public string Note { get; set; }
        public EStatusControlLoan StatusControlLoan { get; set; }
    }
}

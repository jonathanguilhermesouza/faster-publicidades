
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ContractCommands
{
    public class CreateContractCommand
    {
        public int IdContract { get; private set; }
        public int IdCompany { get; set; }
        public int IdDayOfMonth { get; set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public EStatusContract StatusContract { get; private set; }
        public string Note { get; private set; }

        public CreateContractCommand(int idCompany, int idDayOfMonth, DateTime dateStart, DateTime dateEnd, string note)
        {
            this.IdCompany = idCompany;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.Note = note;
            this.IdDayOfMonth = idDayOfMonth;
        }
    }
}

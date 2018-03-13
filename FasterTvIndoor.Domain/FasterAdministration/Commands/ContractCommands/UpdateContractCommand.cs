using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ContractCommands
{
    public class UpdateContractCommand
    {
        public int IdContract { get; private set; }
        public int IdCompany { get; private set; }
        public int IdDayOfMonth { get; set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public EStatusContract StatusContract { get; private set; }
        public string Note { get; private set; }

        public UpdateContractCommand(int idContract, int idCompany,int idDayOfMonth, DateTime dateStart, DateTime dateEnd, EStatusContract statusContract, string note)
        {
            this.IdContract = idContract;
            this.IdCompany = idCompany;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.StatusContract = statusContract;
            this.Note = note;
        }
    }
}

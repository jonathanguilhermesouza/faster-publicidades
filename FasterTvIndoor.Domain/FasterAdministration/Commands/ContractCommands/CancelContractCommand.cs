using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ContractCommands
{
    public class CancelContractCommand
    {
        public int IdContract { get; private set; }
        public int IdCompany { get; set; }
        //public int IdPlan { get; set; }
        public DateTime DateEnd { get; private set; }
        public EStatusContract StatusContract { get; private set; }
        public string Note { get; private set; }

        public CancelContractCommand(int idContract, int idCompany/*, int idPlan*/, string note)
        {
            this.IdContract = idContract;
            this.IdCompany = IdCompany;
            //this.IdPlan = idPlan;
            this.DateEnd = DateTime.Now;
            this.StatusContract = EStatusContract.Cancelado;
            this.Note = note;
        }
    }
}

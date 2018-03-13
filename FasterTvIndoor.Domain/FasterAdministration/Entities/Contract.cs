using FasterTvIndoor.Domain.FasterAdministration.Commands.ContractCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using System;


namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class Contract
    {
        public Contract() { }
        //public Contract(DateTime dateStart, DateTime dateEnd, Company company, string note)
        //{
        //    this.DateStart = dateStart;
        //    this.DateEnd = dateEnd;
        //    this.Company = company;
        //    this.Note = note;
        //}

        public Contract(DateTime dateStart, DateTime dateEnd, int idCompany, int idDayOfMonth/*, int idPlan*/, string note)
        {
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.IdCompany = idCompany;
            this.Note = note;
            this.IdDayOfMonth = idDayOfMonth;
            //this.IdPlan = idPlan;
        }

        public int IdContract { get; private set; }
        public int IdCompany { get; set; }
        public int IdDayOfMonth { get; set; }
        //public int IdPlan { get; set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public EStatusContract StatusContract { get; private set; }
        //public Plan Plan { get; private set; }
        public string Note { get; private set; }
        public virtual DayOfMonth DayOfMonth { get; private set; }
        public virtual Company Company { get; private set; }

        public void Register()
        {
            if (!this.RegisterContractScopeIsValid())
                return;

            this.StatusContract = EStatusContract.Vigente;
        }

        public void UpdateContract(UpdateContractCommand command)
        {
            if (!this.UpdateContractScopeIsValid(command))
                return;

            this.DateStart = command.DateStart;
            this.DateEnd = command.DateEnd;
            this.IdCompany = command.IdCompany;
            //this.IdPlan = command.IdPlan;
            this.StatusContract = command.StatusContract;
            this.Note = command.Note;
        }

        public void CancelContract(CancelContractCommand command)
        {
            if (!this.CancelContractScopeIsValid(command))
                return;

            this.IdCompany = command.IdContract;
            //this.IdPlan = command.IdPlan;
            this.DateEnd = command.DateEnd;
            this.StatusContract = command.StatusContract;
            this.Note = command.Note;
        }

    }
}

using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.BackOffice.Entities;
using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class Company
    {
        public Company() { }
        public Company(
                        string companyName,
                        string fantasyName,
                        string stateInscription,
                        string cnpj,
                        string email,
                        EClassificationCompany classificationCompany,
                        ESizeCompany sizeCompany,
                        List<AddressCompany> listAddressCompany,
                        List<PhoneCompany> listPhonesCompany
        )
        {
            this.CompanyName = companyName;
            this.FantasyName = fantasyName;
            this.StateInscription = stateInscription;
            this.SizeCompany = sizeCompany;
            this.Cnpj = cnpj;
            this.Email = email;
            this.DateRegister = DateTime.Now;
            this.ClassificationCompany = classificationCompany;
            this.ListAddressCompany = listAddressCompany;
            this.ListPhonesCompany = listPhonesCompany;
            this.HaveContract = false;
        }

        // construtor para criacao automatica do bd
        public Company(
                        int idCompany,
                        string companyName,
                        string fantasyName,
                        string stateInscription,
                        string cnpj,
                        string email,
                        EClassificationCompany classificationCompany,
                        EStatusCompany statusCompany,
                        ESizeCompany sizeCompany
            //List<AddressCompany> listAddressCompany
        )
        {
            this.IdCompany = idCompany;
            this.CompanyName = companyName;
            this.FantasyName = fantasyName;
            this.StateInscription = stateInscription;
            this.SizeCompany = sizeCompany;
            this.Cnpj = cnpj;
            this.Email = email;
            this.DateRegister = DateTime.Now;
            this.ClassificationCompany = classificationCompany;
            this.StatusCompany = statusCompany;
            this.HaveContract = false;
            //this.ListAddressCompany = listAddressCompany;

        }
        public int IdCompany { get; private set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; private set; }
        public string StateInscription { get; set; }
        public string Cnpj { get; private set; }
        public string Email { get; set; }
        public bool HaveContract { get; set; }
        public DateTime DateRegister { get; private set; }
        public EClassificationCompany ClassificationCompany { get; private set; }
        public EStatusCompany StatusCompany { get; private set; }
        public ESizeCompany SizeCompany { get; private set; }
        public virtual ICollection<AddressCompany> ListAddressCompany { get; private set; }
        public virtual ICollection<Contract> ListContract { get; private set; }
        public virtual ICollection<PhoneCompany> ListPhonesCompany { get; private set; }
        public virtual ICollection<EmployeeCompany> ListEmployedCompany { get; private set; }
        public virtual ICollection<ControlLoan> ListControlLoan { get; private set; }
        public virtual ICollection<LogotipoCompany> ListLogotipoCompany { get; private set; }
        public virtual ICollection<Video> ListVideo { get; private set; }
        public virtual ICollection<PaymentToCompany> ListPaymentToCompany { get; private set; }
        public virtual ICollection<HistoryEquipment> ListHistoryEquipment { get; private set; }
        

        public void Register()
        {
            if (!this.RegisterCompanyScopeIsValid())
                return;

            this.StatusCompany = EStatusCompany.Ativa;
        }

        public void UpdateHaveContract(bool haveContract)
        {
            this.HaveContract = haveContract;
        }

        public void UpdateCompany(UpdateCompanyCommand command, EStatusCompany status)
        {
            if (!this.UpdateCompanyScopeIsValid(command, status))
                return;

            this.CompanyName = command.CompanyName;
            this.ClassificationCompany = command.ClassificationCompany;
            this.Cnpj = command.Cnpj;
            this.Email = command.Email;
            this.StateInscription = command.StateInscription;
            this.StatusCompany = command.StatusCompany;
            this.FantasyName = command.FantasyName;
            this.SizeCompany = command.SizeCompany;
        }

        public void DeleteCompany(DeleteCompanyCommand command)
        {
            this.StatusCompany = command.StatusCompany;
        }

    }
}

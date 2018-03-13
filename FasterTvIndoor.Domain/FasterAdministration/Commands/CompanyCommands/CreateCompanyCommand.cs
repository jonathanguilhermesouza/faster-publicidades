using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands
{
    public class CreateCompanyCommand
    {
        public CreateCompanyCommand(string companyName, string fantasyName, string stateInscription, string cnpj, string email, EClassificationCompany classificationCompany, ESizeCompany sizeCompany, List<AddressCompany> listAddressCompany, List<PhoneCompany> listPhonesCompany)
        {
            this.CompanyName = companyName;
            this.FantasyName = fantasyName;
            this.StateInscription = stateInscription;
            this.Cnpj = cnpj;
            this.Email = email;
            this.ClassificationCompany = classificationCompany;
            this.ListAddressCompany = listAddressCompany;
            this.ListPhonesCompany = listPhonesCompany;
            this.SizeCompany = sizeCompany;

        }

        public int IdCompany { get; private set; }
        public string CompanyName { get; set; }
        public string StateInscription { get; set; }
        public string Cnpj { get; private set; }
        public string Email { get; set; }
        public string FantasyName { get; private set; }
        public DateTime DateRegister { get; private set; }
        public EClassificationCompany ClassificationCompany { get; set; }
        public ESizeCompany SizeCompany { get; set; }
        public List<AddressCompany> ListAddressCompany { get; set; }
        public List<PhoneCompany> ListPhonesCompany { get; set; }
    }
}

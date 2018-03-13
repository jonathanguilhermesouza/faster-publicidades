using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands
{
    public class UpdateCompanyCommand
    {
        public UpdateCompanyCommand(int idCompany, string companyName, string fantasyName, string stateInscription, string cnpj,string email, EStatusCompany statusCompany, EClassificationCompany classificationCompany, ESizeCompany sizeCompany)
        {
            this.IdCompany = idCompany;
            this.CompanyName = companyName;
            this.FantasyName = fantasyName;
            this.StateInscription = stateInscription;
            this.Cnpj = cnpj;
            this.Email = email;
            this.StatusCompany = statusCompany;
            this.ClassificationCompany = classificationCompany;
            this.SizeCompany = sizeCompany;
        }

        public int IdCompany { get; private set; }
        public string CompanyName { get; set; }
        public string StateInscription { get; set; }
        public string Cnpj { get; private set; }
        public string FantasyName { get; private set; }
        public string Email { get; private set; }
        public EStatusCompany StatusCompany { get; private set; }
        public EClassificationCompany ClassificationCompany { get; private set; }
        public ESizeCompany SizeCompany { get; private set; }
    }
}

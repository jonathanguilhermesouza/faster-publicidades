using FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class CompanyScopes
    {
        public static bool RegisterCompanyScopeIsValid(this Company company)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertTrue(!(company.ListAddressCompany.Count == 0), "O Endereço é obrigatório"),
                    AssertionConcern.AssertTrue(!(company.ListPhonesCompany.Count == 0), "O Telefone é obrigatório"),
                    AssertionConcern.AssertNotNull(company.FantasyName, "O Nome fantasia é obrigatório"),
                    AssertionConcern.AssertNotNull(company.Cnpj, "O CNPJ é obrigatório"),
                    AssertionConcern.AssertNotNull(company.Email, "O Email é obrigatório"),
                    AssertionConcern.AssertNotNull(company.StateInscription, "A Inscrição Estadual é obrigatório"),
                    AssertionConcern.AssertNotNull(company.StatusCompany, "O Status da empresa é obrigatório"),
                    AssertionConcern.AssertNotNull(company.ClassificationCompany, "A Classificação da empresa é obrigatório"),
                    AssertionConcern.AssertNotNull(company.CompanyName, "A Razão Social da empresa é obrigatório"),
                    AssertionConcern.AssertLength(company.Cnpj, 13, 15, "O Cnpj deve ter 14 caracters"),
                    AssertionConcern.AssertLength(company.StateInscription, 7, 7, "A Inscrição estadual deve ter 7 caracters"),
                    AssertionConcern.AssertLength(company.FantasyName, 5, 100, "O Nome Fantasia deve ter entre 5 e 100 caracters"),
                    AssertionConcern.AssertLength(company.CompanyName, 10, 100, "A Razão Social deve ter entre 10 e 100 caracters"),
                    AssertionConcern.AssertLength(company.Email, 10, 50, "O Email deve ter entre 10 e 50 caracters")
                );

        }

        public static bool UpdateCompanyScopeIsValid(this Company company,UpdateCompanyCommand updateCompany,EStatusCompany status)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(updateCompany.FantasyName, "O Nome fantasia é obrigatório"),
                    AssertionConcern.AssertNotEmpty(updateCompany.Cnpj, "O CNPJ é obrigatório"),
                    AssertionConcern.AssertNotEmpty(updateCompany.Email, "O Email é obrigatório"),
                    AssertionConcern.AssertNotEmpty(updateCompany.StateInscription, "A Inscrição Estadual é obrigatório"),
                    AssertionConcern.AssertNotNull(updateCompany.StatusCompany, "O Status da empresa é obrigatório"),
                    AssertionConcern.AssertNotNull(updateCompany.ClassificationCompany, "A Classificação da empresa é obrigatório"),
                    AssertionConcern.AssertNotEmpty(updateCompany.CompanyName, "A Razão Social da empresa é obrigatório"),
                    AssertionConcern.AssertLength(updateCompany.Cnpj, 13, 15, "O Cnpj deve ter 14 caracters"),
                    AssertionConcern.AssertLength(updateCompany.StateInscription, 7, 7, "A Inscrição estadual deve ter 7 caracters"),
                    AssertionConcern.AssertLength(updateCompany.FantasyName, 5, 100, "O Nome Fantasia deve ter entre 5 e 100 caracters"),
                    AssertionConcern.AssertLength(updateCompany.CompanyName, 10, 100, "A Razão Social deve ter entre 10 e 100 caracters"),
                    AssertionConcern.AssertLength(updateCompany.Email, 10, 50, "O Email deve ter entre 10 e 50 caracters"),
                    AssertionConcern.AssertTrue(status.Equals(EStatusCompany.Ativa), "É permitido editar apenas Empresas ativas")
                );

        }

        public static bool UpdateEmailCompanyScopeIsValid(this Company company, string email)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(email, "O Email é obrigatório")
                );

        }


    }
}

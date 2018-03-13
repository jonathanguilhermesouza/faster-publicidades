using FasterTvIndoor.Domain.FasterAdministration.Commands.ContractCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class ContractScopes
    {
        public static bool RegisterContractScopeIsValid(this Contract contract)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(contract.IdCompany, "Empresa não informada"),
                AssertionConcern.AssertTrue(!(contract.DateStart > contract.DateEnd), "Data de início maior que a data de fim")
            );
        }

        public static bool UpdateContractScopeIsValid(this Contract contract, UpdateContractCommand command)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(command.IdCompany, "Empresa não informada"),
                AssertionConcern.AssertTrue(!(command.DateStart > contract.DateEnd), "Data de início maior que a data de fim")
            );
        }

        public static bool CancelContractScopeIsValid(this Contract contract, CancelContractCommand command)
        {
            return AssertionConcern.IsSatisfiedBy(
                //AssertionConcern.AssertNotEmpty(command.Note, "É preciso informar o motivo do cancelamento do contrato"),
                //AssertionConcern.AssertLength(command.Note, 8, 2000, "Tamanho do texto inválido")
            );
        }
    }
}

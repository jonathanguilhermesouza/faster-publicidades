using FasterTvIndoor.Domain.FasterAdministration.Commands.ControlLoanCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class ControlLoanScopes
    {
        public static bool CreateControlLoantScopesIsValid(this ControlLoan controlLoan)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotNull(controlLoan.DateLocation, "A Data de empréstimo é obrigatório"),
                    AssertionConcern.AssertTrue(!(controlLoan.DateLocation > controlLoan.DateEndLocation), "A data de fim do empréstimo deve ser maior que a data de início"),
                    AssertionConcern.AssertNotNull(controlLoan.DateLocation, "A Data de fim do empréstimo é obrigatório")
                );
        }

        public static bool UpdateControlLoantScopesIsValid(this ControlLoan controlLoan, UpdateControlLoanCommand command, EStatusControlLoan status)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotNull(controlLoan.DateLocation, "A Data de empréstimo é obrigatório"),
                    AssertionConcern.AssertNotNull(controlLoan.DateLocation, "A Data de fim do empréstimo é obrigatório"),
                    AssertionConcern.AssertTrue(!(controlLoan.DateLocation > command.DateEndLocation), "A data de fim do empréstimo deve ser maior que a data de início"),
                    AssertionConcern.AssertTrue(status.Equals(EStatusControlLoan.Vigente), "É permitido editar apenas empréstimos vigentes")
                );
        }
    }
}

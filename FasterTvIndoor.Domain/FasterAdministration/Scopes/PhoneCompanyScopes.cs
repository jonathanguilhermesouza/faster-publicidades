using FasterTvIndoor.Domain.FasterAdministration.Commands.PhoneCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class PhoneCompanyScopes
    {
        public static bool CreatePhoneCompanyScopeIsValid(this PhoneCompany phoneCompany)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(phoneCompany.Number, "O Número é obrigatório")
                );

        }

        public static bool UpdatePhoneCompanyScopeIsValid(this PhoneCompany phoneCompany, UpdatePhoneCompanyCommand command)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(command.Number, "O Número é obrigatório")
                );

        }
    }
}

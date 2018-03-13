using FasterTvIndoor.Domain.FasterAdministration.Commands.AddressCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class AddressCompanyScopes
    {
        public static bool UpdatePhoneCompanyScopeIsValid(this AddressCompany category, UpdateAddressCompanyCommand command)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(command.Cep, "A Cep é obrigatória"),
                AssertionConcern.AssertNotEmpty(command.Number, "O Número é obrigatório")
            );
        }        
    }
}

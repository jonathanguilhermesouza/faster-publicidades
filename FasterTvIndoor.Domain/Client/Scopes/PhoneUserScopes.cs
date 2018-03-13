using FasterTvIndoor.Domain.Client.Commands.PhoneUserCommands;
using FasterTvIndoor.Domain.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.Client.Scopes
{
    public static class PhoneUserScopes
    {
        public static bool CreatePhoneUserScopeIsValid(this PhoneUser phoneUser)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(phoneUser.Number, "O Número é obrigatório")
                );

        }

        public static bool UpdatePhoneUserScopeIsValid(this PhoneUser phoneUser,UpdatePhoneUserCommand command)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(command.Number, "O Número é obrigatório")
                );

        }
    }
}

using FasterTvIndoor.Domain.Client.Commands.AddressUserCommands;
using FasterTvIndoor.Domain.Client.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.Client.Scopes
{
    public static class AddressUserScopes
    {
        public static bool UpdateAddressUserScopeIsValid(this AddressUser addressUser, UpdateAddressUserCommand command)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(command.Bairro, "O Bairro é obrigatório"),
                    AssertionConcern.AssertNotEmpty(command.Cep, "O Cep é obrigatório"),
                    AssertionConcern.AssertNotEmpty(command.Number, "O Número é obrigatório")
                );

        }

        public static bool CreateAddressUserScopeIsValid(this AddressUser addressUser)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(addressUser.Bairro, "O Bairro é obrigatório"),
                    AssertionConcern.AssertNotEmpty(addressUser.Cep, "O Cep é obrigatório"),
                    AssertionConcern.AssertNotEmpty(addressUser.Number, "O Número é obrigatório")
                );

        }
        
    }
}

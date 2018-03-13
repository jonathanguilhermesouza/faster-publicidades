using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.Client.Commands.UserCommands;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.Client.Scopes
{
    public static class UserScopes
    {
        public static bool UpdateUserScopeIsValid(this User user, UpdateUserCommand command)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(command.Email, "O Email é obrigatório"),
                    AssertionConcern.AssertNotEmpty(command.Name, "O Nome é obrigatória"),
                    AssertionConcern.AssertNotEmpty(command.LastName, "O Sobrenome é obrigatória")
                );
        }
    }
}

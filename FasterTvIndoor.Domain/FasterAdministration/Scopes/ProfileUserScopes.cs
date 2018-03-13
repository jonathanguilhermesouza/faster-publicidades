using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class ProfileUserScopes
    {
        public static bool CreateProfileUserScopeIsValid(this ProfileUser profile)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(profile.Profile, "O profile é obrigatorio"),
                AssertionConcern.AssertLength(profile.Profile, 3, 20, " A quantidade de caracter é inválida")
            );
        }

        public static bool UpdateProfileUserScopeisValid(this ProfileUser profile, string newProfile)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(profile.Profile, "O profile é obrigatorio"),
                AssertionConcern.AssertLength(profile.Profile, 3, 20, " A quantidade de caracter é inválida"),
                AssertionConcern.AssertNotEmpty(newProfile, "O profile é obrigatorio"),
                AssertionConcern.AssertLength(newProfile, 3, 20, " A quantidade de caracter é inválida")
            );
        }
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class TypeVideoScopes
    {
        public static bool CreateTypeVideoScopeIsValid(this TypeVideo typeVideo)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(typeVideo.Type, "O tipo é obrigatório"),
                    AssertionConcern.AssertLength(typeVideo.Type, 2, 15, "O tipo deve ter entre 2 e 15 caracters")
                );
        }

        public static bool UpdateTypeVideoScopeIsValid(this TypeVideo typeEquipment, UpdateTypeVideoCommand newTypeVideo)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(newTypeVideo.Type, "O tipo é obrigatório"),
                    AssertionConcern.AssertLength(newTypeVideo.Type, 2, 15, "O tipo deve ter entre 2 e 15 caracters")
                );
        }
    }
}

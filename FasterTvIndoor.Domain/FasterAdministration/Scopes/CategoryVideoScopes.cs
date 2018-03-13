using FasterTvIndoor.Domain.FasterAdministration.Commands.CategoryVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class CategoryVideoScopes
    {
        public static bool CreateCategoryVideoScopeIsValid(this CategoryVideo categoryVideo)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(categoryVideo.Category, "A categoria é obrigatória"),
                    AssertionConcern.AssertLength(categoryVideo.Category, 2, 15, "A categoria deve ter entre 2 e 15 caracters")
                );
        }

        public static bool UpdateCategoryVideoScopeIsValid(this CategoryVideo typeEquipment, UpdateCategoryVideoCommand newCategoryVideo)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(newCategoryVideo.Category, "A categoria é obrigatória"),
                    AssertionConcern.AssertLength(newCategoryVideo.Category, 2, 15, "O tipo deve ter entre 2 e 15 caracters")
                );
        }
    }
}

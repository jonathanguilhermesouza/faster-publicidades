using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeEquipmentCommands;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class TypeEquipmentScopes
    {
        public static bool CreateTypeEquipmentScopeIsValid(this TypeEquipment typeEquipment)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(typeEquipment.Type, "O tipo é obrigatório"),
                    AssertionConcern.AssertLength(typeEquipment.Type, 2, 15, "O tipo deve ter entre 2 e 15 caracters")
                );
        }

        public static bool UpdateTypeEquipmentScopeIsValid(this TypeEquipment typeEquipment, UpdateTypeEquipmentCommand newTypeEquipment)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(newTypeEquipment.Type, "O tipo é obrigatório"),
                    AssertionConcern.AssertLength(newTypeEquipment.Type, 2, 15, "O tipo deve ter entre 2 e 15 caracters")
                );
        }
    }
}

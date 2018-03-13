using FasterTvIndoor.Domain.FasterAdministration.Commands.EquipmentCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class EquipmentScopes
    {
        public static bool CreateEquipmentScopeIsValid(this Equipment equipment)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(equipment.Model, "O Modelo é obrigatório"),
                AssertionConcern.AssertNotEmpty(equipment.Patrimony, "O Patrimônio é obrigatório"),
                AssertionConcern.AssertNotEmpty(equipment.SerialNumber, "O Serial é obrigatório")
                );
        }

        public static bool UpdateEquipmentScopeIsValid(this Equipment equipment, UpdateEquipmentCommand command, EStatusEquipment status )
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(command.Model, "O Modelo é obrigatório"),
                AssertionConcern.AssertNotEmpty(command.Patrimony, "O Patrimônio é obrigatório"),
                AssertionConcern.AssertNotEmpty(command.SerialNumber, "O Serial é obrigatório"),
                AssertionConcern.AssertTrue(!status.Equals(EStatusEquipment.Desabilitado), "Não é permitido editar equipamentos desabilitados")
                );
        }
    }
}

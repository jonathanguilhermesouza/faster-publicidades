using FasterTvIndoor.Domain.FasterAdministration.Commands.PlanCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class PlanScopes
    {
        public static bool CreatePlanScopeIsValid(this Plan plan)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(plan.Description, "A descrição é obrigatória"),
                    AssertionConcern.AssertNotEmpty(plan.Title, "O titulo é obrigatório"),
                    AssertionConcern.AssertTrue(!(plan.ValueEquipmentAdditional == 0), "O valor do equipamento adicional é obrigatório"),
                    AssertionConcern.AssertTrue(!(plan.ValueEquipmentMain == 0), "O valor do equipamento principal é obrigatório")
                );
        }

        public static bool UpdatePlanScopeIsValid(this Plan plan, UpdatePlanCommand newPlan)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(newPlan.Description, "A descrição é obrigatória"),
                    AssertionConcern.AssertNotEmpty(newPlan.Title, "O titulo é obrigatório"),
                    AssertionConcern.AssertTrue(!(newPlan.ValueEquipmentAdditional == 0), "O valor do equipamento adicional é obrigatório"),
                    AssertionConcern.AssertTrue(!(newPlan.ValueEquipmentMain == 0), "O valor do equipamento principal é obrigatório")
                );
        }
    }
}

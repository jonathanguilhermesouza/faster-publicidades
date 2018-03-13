using FasterTvIndoor.Domain.FasterAdministration.Commands.PlanCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IPlanApplicationService
    {
        List<Plan> GetAll();
        List<Plan> GetByRange(int skip, int take, string word);
        Plan GetById(int id);
        Plan Create(CreatePlanCommand command);
        Plan Update(UpdatePlanCommand command);
        Plan Delete(/*DeletePlanCommand command*/);
        int GetCount(string word);
    }
}

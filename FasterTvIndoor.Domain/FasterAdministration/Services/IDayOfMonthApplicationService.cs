using FasterTvIndoor.Domain.FasterAdministration.Commands.DayOfMonth;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IDayOfMonthApplicationService
    {
        List<DayOfMonth> GetAll();
        DayOfMonth GetById(int id);
        DayOfMonth Create(CreateDayOfMonthCommand command);
        DayOfMonth Update(UpdateDayOfMonthCommand command);
        DayOfMonth Delete(/*DeleteSectorCompanyCommand command*/);
    }
}

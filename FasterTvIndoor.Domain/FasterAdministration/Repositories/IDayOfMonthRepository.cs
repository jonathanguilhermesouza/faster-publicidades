using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IDayOfMonthRepository
    {
        List<DayOfMonth> GetAll();
        DayOfMonth GetById(int id);
        void Update(DayOfMonth day);
        void Delete(DayOfMonth day);
        void Create(DayOfMonth day);
    }
}

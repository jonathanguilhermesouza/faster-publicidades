using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IPlanRepository
    {
        List<Plan> GetAll();
        List<Plan> GetByRange(int skip, int take,string word);
        Plan GetById(int id);
        void Create(Plan plan);
        void Update(Plan plan);
        void Delete(Plan plan);
        int GetCount(string word);
    }
}

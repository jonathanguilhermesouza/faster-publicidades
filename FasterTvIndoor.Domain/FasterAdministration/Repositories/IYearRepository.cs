using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IYearRepository
    {
        List<Year> GetAll();
        Year GetById(int id);
        void Update(Year year);
        void Delete(Year year);
        void Create(Year year);
        int GetCount(string word);
    }
}

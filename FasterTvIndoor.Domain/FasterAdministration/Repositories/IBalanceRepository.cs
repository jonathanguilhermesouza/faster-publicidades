using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IBalanceRepository
    {
        List<Balance> GetAll();
        List<Balance> GetByRange(int skip, int take, EStatusVideo statusVideo ,string word);
        int GetCount(string word, int idCompany);
    }
}

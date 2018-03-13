using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IBalanceApplicationService
    {
        List<Balance> GetAll();
        List<Balance> GetByRange(int skip, int take, EStatusVideo statusVideo, string word);
        List<Balance> GetByRange(int skip, int take, EStatusVideo statusVideo, int id, string word);
        decimal GetValueByVideo(int id);
        int GetCount(string word, int idCompany);
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IContractRepository
    {
        List<Contract> GetAll();
        List<Contract> GetByRange(int skip, int take, string word, EStatusContract statusContract);
        Contract GetById(int id);
        void Create(Contract contract);
        void Update(Contract contract);
        void Cancel(Contract contract);
        int GetCount(string word, EStatusContract statusContract);

    }
}

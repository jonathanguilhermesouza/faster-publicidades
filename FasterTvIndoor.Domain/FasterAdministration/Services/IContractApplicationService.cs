using FasterTvIndoor.Domain.FasterAdministration.Commands.ContractCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IContractApplicationService
    {
        List<Contract> GetAll();
        List<Contract> GetByRange(int skip, int take, string word, EStatusContract statusContract);
        Contract GetById(int id);
        Contract Create(CreateContractCommand command);
        Contract Update(UpdateContractCommand command);
        Contract Cancel(CancelContractCommand command);
        int GetCount(string word, EStatusContract statusContract);

    }
}

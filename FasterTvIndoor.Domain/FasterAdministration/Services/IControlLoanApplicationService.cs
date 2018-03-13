using FasterTvIndoor.Domain.FasterAdministration.Commands.ControlLoanCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IControlLoanApplicationService
    {
        List<ControlLoan> GetAll();
        List<ControlLoan> GetAllControlLoanEquipmentByVideo(int idVideo, int idTypeEquipment, EStatusControlLoan status);
        List<ControlLoan> GetAllControlLoanEquipment(int idTypeEquipment, EStatusControlLoan status);
        List<ControlLoan> GetByRange(int skip, int take, string word, EStatusControlLoan status);
        ControlLoan GetById(int id);
        ControlLoan Create(CreateControlLoanCommand command);
        ControlLoan Update(UpdateControlLoanCommand command);
        ControlLoan Delete(DeleteControlLoanCommand command);
        int GetCount(string word, EStatusControlLoan status);
    }
}

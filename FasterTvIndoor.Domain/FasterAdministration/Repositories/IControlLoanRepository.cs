using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IControlLoanRepository
    {
        List<ControlLoan> GetAll();
        List<ControlLoan> GetAllControlLoanEquipmentByVideo(int idVideo, int idTypeEquipment, EStatusControlLoan status);
        List<ControlLoan> GetAllControlLoanEquipment(int idTypeEquipment, EStatusControlLoan status);
        List<ControlLoan> GetByRange(int skip, int take, string word, EStatusControlLoan status);
        ControlLoan GetById(int id);
        ControlLoan GetByIdCompany(int id);
        void Create(ControlLoan controlLoan);
        void Update(ControlLoan controlLoan);
        void Delete(ControlLoan controlLoan);
        int GetCount(string word, EStatusControlLoan status);
    }
}

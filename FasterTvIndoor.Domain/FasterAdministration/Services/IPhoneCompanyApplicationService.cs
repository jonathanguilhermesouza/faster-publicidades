using FasterTvIndoor.Domain.FasterAdministration.Commands.PhoneCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IPhoneCompanyApplicationService
    {
        PhoneCompany GetById(int id);
        PhoneCompany Update(UpdatePhoneCompanyCommand command);
        PhoneCompany Delete(DeletePhoneCompanyCommand command);
        PhoneCompany Create(CreatePhoneCompanyCommand command);
    }
}

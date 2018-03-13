using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface ISizeCompanyApplicationService
    {
        List<SizeCompany> GetAll();
    }
}

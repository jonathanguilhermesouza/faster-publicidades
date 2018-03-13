using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IClassificationCompanyApplicationService
    {
        List<ClassificationCompany> GetAll();

    }
}

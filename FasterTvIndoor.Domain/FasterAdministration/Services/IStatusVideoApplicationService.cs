using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IStatusVideoApplicationService
    {
        List<StatusVideo> GetAll();
    }
}

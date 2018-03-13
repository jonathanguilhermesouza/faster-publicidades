using FasterTvIndoor.Domain.Account.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.Account.Services
{
    public interface IStatusUserApplicationService
    {
        List<StatusUser> GetAll();
    }
}

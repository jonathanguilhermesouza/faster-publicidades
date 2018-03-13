using FasterTvIndoor.Domain.Account.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.Account.Repositories
{
    public interface IStatusUserRepository
    {
        List<StatusUser> GetAll();
    }
}

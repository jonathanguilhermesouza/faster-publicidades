using FasterTvIndoor.Domain.FasterAdministration.Commands.YearCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IYearApplicationService
    {
        List<Year> GetAll();
        Year GetById(int id);
        Year Create(CreateYearCommand command);
        Year Update(UpdateYearCommand command);
    }
}

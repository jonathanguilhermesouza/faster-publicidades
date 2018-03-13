using FasterTvIndoor.Domain.FasterAdministration.Commands.SectorCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface ISectorCompanyApplicationService
    {
        List<SectorCompany> GetAll();
        List<SectorCompany> GetByRange(int skip, int take);
        SectorCompany GetById(int id);
        SectorCompany Create(CreateSectorCompanyCommand command);
        SectorCompany Update(UpdateSectorCompanyCommand command);
        SectorCompany Delete(/*DeleteSectorCompanyCommand command*/);
        int GetCount();
    }
}

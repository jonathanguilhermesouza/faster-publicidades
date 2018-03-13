using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface ISectorCompanyRepository
    {
        List<SectorCompany> GetAll();
        List<SectorCompany> GetByRange(int skip, int take);
        SectorCompany GetById(int id);
        void Create(SectorCompany sector);
        void Update(SectorCompany sector);
        void Delete(SectorCompany sector);
        int GetCount();
    }
}

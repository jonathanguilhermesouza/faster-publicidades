using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetByRange(int skip, int take, string word, EStatusCompany status);
        Company GetById(int id);
        void Create(Company company);
        void Update(Company company);
        void Delete(Company company);
        int GetCount(string word, EStatusCompany status);
    }
}

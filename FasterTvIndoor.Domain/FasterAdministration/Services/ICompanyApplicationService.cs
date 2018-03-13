using FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface ICompanyApplicationService
    {
        int GetCount(string word, EStatusCompany status);
        List<Company> GetByRange(int skip, int take, string word, EStatusCompany status);
        Company GetById(int id);
        Company Create(CreateCompanyCommand company);
        Company Update(UpdateCompanyCommand command);
        Company Delete(DeleteCompanyCommand command);

    }
}

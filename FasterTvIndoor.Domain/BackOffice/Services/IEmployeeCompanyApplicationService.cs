using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.BackOffice.Commands.EmployeeCompany;
using FasterTvIndoor.Domain.BackOffice.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.BackOffice.Services
{
    public interface IEmployeeCompanyApplicationService
    {
        int GetCount(string word, EStatusUser status);
        List<EmployeeCompany> GetByRange(int skip, string word, EStatusUser status);
        EmployeeCompany GetById(int id);
        EmployeeCompany GetByEmail(string email);
        EmployeeCompany Create(CreateEmployeeCompanyCommand command);
        EmployeeCompany Update(UpdateEmployeeCompanyCommand command);
        EmployeeCompany Delete(DeleteEmployeeCompanyCommand command);
        
    }
}

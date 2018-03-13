using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.BackOffice.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.BackOffice.Repositories
{
    public interface IEmployeeCompanyRepository
    {
        int GetCount(string word, EStatusUser status);
        List<EmployeeCompany> GetByRange(int skip, string word, EStatusUser status);
        EmployeeCompany GetById(int id);
        EmployeeCompany GetByEmail(string email);
        void Create(EmployeeCompany employee);
        void Update(EmployeeCompany employee);
        void Delete(EmployeeCompany employee);
        
    }
}

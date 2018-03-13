using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IPhoneCompanyRepository
    {
        List<PhoneCompany> GetAll();
        PhoneCompany GetById(int id);
        void Update(PhoneCompany phone);
        void Delete(PhoneCompany phone);
        void Create(PhoneCompany phone);
    }
}

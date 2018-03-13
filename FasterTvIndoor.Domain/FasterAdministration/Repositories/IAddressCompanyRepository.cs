using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IAddressCompanyRepository
    {
        List<AddressCompany> GetAll();
        AddressCompany GetById(int id);
        void Update(AddressCompany address);
        void Delete(AddressCompany address);
    }
}

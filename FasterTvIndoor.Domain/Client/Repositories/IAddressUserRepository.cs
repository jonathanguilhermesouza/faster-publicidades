using FasterTvIndoor.Domain.Client.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.Client.Repositories
{
    public interface IAddressUserRepository
    {
        List<AddressUser> GetAll();
        AddressUser GetById(int id);
        void Create(AddressUser address);
        void Update(AddressUser address);
        void Delete(AddressUser address);
    }
}

using FasterTvIndoor.Domain.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.Client.Repositories
{
    public interface IPhoneUserRepository
    {
        List<PhoneUser> GetAll();
        PhoneUser GetById(int id);
        void Update(PhoneUser phone);
        void Delete(PhoneUser phone);
        void Create(PhoneUser phone);
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IProfileUserRepository
    {
        List<ProfileUser> GetAll();
        List<ProfileUser> GetByRange(int skip, int take);
        ProfileUser GetById(int id);
        void Create(ProfileUser profile);
        void Update(ProfileUser profile);
        void Delete(ProfileUser profile);
        int GetCount();
    }
}

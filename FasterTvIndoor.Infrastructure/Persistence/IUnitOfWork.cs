using System;

namespace FasterTvIndoor.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}

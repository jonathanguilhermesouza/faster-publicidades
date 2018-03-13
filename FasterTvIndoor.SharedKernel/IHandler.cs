using FasterTvIndoor.SharedKernel.Events.Contracts;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.SharedKernel
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Nofify();
        bool HasNotifications();
    }
}

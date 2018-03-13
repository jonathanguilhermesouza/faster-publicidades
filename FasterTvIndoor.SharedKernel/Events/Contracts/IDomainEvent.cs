using System;

namespace FasterTvIndoor.SharedKernel.Events.Contracts
{
    public interface IDomainEvent
    {
        DateTime DataOccurred { get; }
    }
}

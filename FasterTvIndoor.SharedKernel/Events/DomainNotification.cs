using FasterTvIndoor.SharedKernel.Events.Contracts;
using System;

namespace FasterTvIndoor.SharedKernel.Events
{
    public class DomainNotification : IDomainEvent
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public DateTime DataOccurred { get; private set; }

        public DomainNotification(string key, string value)
        {
            this.Key = key;
            this.Value = value;
            this.DataOccurred = DateTime.Now;
        }
    }
}

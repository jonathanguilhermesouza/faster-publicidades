using System;

namespace FasterTvIndoor.Domain.Account.Entities
{
    public class Claim
    {
        public Claim(Guid id, string name)
        {
            this.Id = Id;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}

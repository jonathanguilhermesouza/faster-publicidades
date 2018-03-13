using FasterTvIndoor.Domain.Client.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.Client
{
    public class AccountCurrentMap : EntityTypeConfiguration<AccountCurrent>
    {
        public AccountCurrentMap()
        {

            ToTable("AccountsCurrent", "Client");

            HasKey(a => a.IdAccountCurrent);

            HasRequired(a => a.User)
                .WithMany(a => a.ListAccountCurrent);

            Property(a => a.Agency)
                .HasMaxLength(10);

            Property(a => a.Account)
                .HasMaxLength(20);
        }
    }
}

using FasterTvIndoor.Domain.Account.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.Account
{
    public class ClaimsMap : EntityTypeConfiguration<Claim>
    {
        public ClaimsMap()
        {
            ToTable("Claims", "Account");

            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasColumnName("IdClaim");

            Property(a => a.Name)
                .HasColumnName("Name");
            
        }
    }
}

using FasterTvIndoor.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace RedeFaster.Infrastructure.Persistence.Mapping.Client
{
    public class PhoneUserMap : EntityTypeConfiguration<PhoneUser>
    {
        public PhoneUserMap()
        {
            ToTable("PhonesUser", "Client");

            HasKey(a => a.IdPhoneUser);

            Property(a => a.Number)
                .HasMaxLength(15)
                .IsRequired();

            HasRequired(a => a.User)
                .WithMany(a => a.ListPhoneUser);
        }
    }
}

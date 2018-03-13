using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class ProfileUserMap : EntityTypeConfiguration<ProfileUser>
    {
        public ProfileUserMap()
        {

            ToTable("ProfilesUser", "FasterAdministration");

            HasKey(a => a.IdProfileUser);

            Property(a => a.Profile)
                .HasMaxLength(20)
                .IsRequired();

        }

    }
}

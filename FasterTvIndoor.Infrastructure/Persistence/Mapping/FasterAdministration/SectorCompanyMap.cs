using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class SectorCompanyMap : EntityTypeConfiguration<SectorCompany>
    {
        public SectorCompanyMap()
        {

            ToTable("SectorsCompany", "FasterAdministration");

            HasKey(a => a.IdSectorCompany);

            Property(a => a.Sector)
                .HasMaxLength(20)
                .IsRequired();

        }
    }
}

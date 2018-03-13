using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class YearMap : EntityTypeConfiguration<Year>
    {
        public YearMap()
        {
            ToTable("Years","FasterAdministration");

            HasKey(a => a.IdYear);

            Property(a => a.Number)
                .IsRequired();
        }
    }
}

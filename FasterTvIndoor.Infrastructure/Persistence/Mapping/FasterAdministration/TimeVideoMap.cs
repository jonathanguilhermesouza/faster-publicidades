using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class TimeVideoMap : EntityTypeConfiguration<TimeVideo>
    {
        public TimeVideoMap()
        {
            ToTable("TimesVideo", "FasterAdministration");

            HasKey(a => a.IdTimeVideo);

            Property(a => a.Time)
                .IsRequired();
        }
    }
}

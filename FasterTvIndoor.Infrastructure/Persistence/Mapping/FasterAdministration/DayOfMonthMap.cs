using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class DayOfMonthMap : EntityTypeConfiguration<DayOfMonth>
    {
        public DayOfMonthMap()
        {
            ToTable("DaysOfMonth","FasterAdministration");

            HasKey(a => a.IdDayOfMonth);

            Property(a => a.Day)
                .IsRequired();
        }
    }
}

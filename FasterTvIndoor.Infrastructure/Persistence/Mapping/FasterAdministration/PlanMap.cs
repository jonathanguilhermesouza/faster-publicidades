using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class PlanMap : EntityTypeConfiguration<Plan>
    {
        public PlanMap()
        {
            ToTable("Plans", "FasterAdministration");

            HasKey(a => a.IdPlan);

            Property(a => a.ValueEquipmentAdditional)
                .HasPrecision(10, 2)
                .IsRequired();

            Property(a => a.ValueEquipmentMain)
                .HasPrecision(10, 2)
                .IsRequired();

            Property(a => a.ValueUpdate)
                .HasPrecision(10, 2)
                .IsRequired();

            Property(a => a.Description)
                .HasMaxLength(100)
                .IsRequired();

            Property(a => a.Title)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class HistoryEquipmentMap : EntityTypeConfiguration<HistoryEquipment>
    {
        public HistoryEquipmentMap()
        {
            ToTable("HistoriesEquipment","FasterAdministration");

            HasKey(a => a.IdHistoryEquipment);

            HasRequired(a => a.Equipment)
                .WithMany(a => a.ListHistoryEquipment);

            HasRequired(a => a.Video)
                .WithMany(a => a.ListHistoryEquipment);

            HasRequired(a => a.Company)
                .WithMany(a => a.ListHistoryEquipment);

            Property(a => a.Action)
                .IsRequired();

            Property(a => a.DateOfRegister)
                .IsRequired();

            Property(a => a.Value)
                .HasPrecision(10, 2);

            Property(a => a.Plan)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

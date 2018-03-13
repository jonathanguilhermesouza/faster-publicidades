using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class EquipmentMap : EntityTypeConfiguration<Equipment>
    {
        public EquipmentMap()
        {

            ToTable("Equipments", "FasterAdministration");

            HasKey(a => a.IdEquipment);

            HasRequired(a => a.TypeEquipment)
                .WithMany(a => a.ListEquipment);

            Property(a => a.Description)
                .HasMaxLength(100);

            Property(a => a.Model)
                .HasMaxLength(50)
                .IsRequired();

            Property(a => a.DateBuy)
                .IsRequired();

            Property(a => a.SerialNumber)
                .HasMaxLength(50)
                .IsRequired();

            Property(a => a.Patrimony)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class TypeEquipmentMap : EntityTypeConfiguration<TypeEquipment>
    {
        public TypeEquipmentMap()
        {
            ToTable("TypesEquipment","FasterAdministration");

            HasKey(a => a.IdTypeEquipment);

            Property(a => a.Type)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}

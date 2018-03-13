using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class TypeVideoMap : EntityTypeConfiguration<TypeVideo>
    {
        public TypeVideoMap()
        {
            ToTable("TypesVideo", "FasterAdministration");

            HasKey(a => a.IdTypeVideo);

            Property(a => a.Type)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
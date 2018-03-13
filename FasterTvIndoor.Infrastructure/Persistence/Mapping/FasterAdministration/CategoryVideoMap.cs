using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class CategoryVideoMap : EntityTypeConfiguration<CategoryVideo>
    {
        public CategoryVideoMap()
        {
            ToTable("CategoriesVideo", "FasterAdministration");

            HasKey(a => a.IdCategoryVideo);

            Property(a => a.Category)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}

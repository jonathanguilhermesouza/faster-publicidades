using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class VideoMap : EntityTypeConfiguration<Video>
    {
        public VideoMap()
        {
            ToTable("Videos", "FasterAdministration");

            HasKey(a => a.IdVideo);

            HasRequired(a => a.Company)
                .WithMany(a => a.ListVideo);

            HasRequired(a => a.TypeVideo)
                .WithMany(a => a.ListVideo);

            HasRequired(a => a.TimeVideo)
                .WithMany(a => a.ListVideo);

            HasRequired(a => a.CategoryVideo)
                .WithMany(a => a.ListVideo);

            HasRequired(c => c.Plan)
              .WithMany(c => c.ListVideo);

            Property(a => a.Status)
                .IsRequired();

            Property(a => a.Url)
                .HasMaxLength(300)
                .IsRequired();

            Property(a => a.DateEnd)
                .IsRequired();

            Property(a => a.DateStart)
                .IsRequired();

            Property(a => a.DateRegister)
                .IsRequired();

            Property(a => a.TvAdditional)
                .IsRequired();

        }
    }
}

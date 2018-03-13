using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class VideoEquipmentMap : EntityTypeConfiguration<VideoEquipment>
    {
        public VideoEquipmentMap()
        {
            ToTable("VideosEquipments","FasterAdministration");

            HasKey(a => a.IdVideoEquipment);

            HasRequired(a => a.Equipment)
                .WithMany(a => a.ListVideoEquipment);

            HasRequired(a => a.Video)
                .WithMany(a => a.ListVideoEquipment);

            HasRequired(a => a.ControlLoan)
               .WithMany(a => a.ListVideoEquipment);

            Property(a => a.Order)
                .IsRequired();

            //Property(a => a.DateUpdate)
            //  .IsRequired();

        }
    }
}

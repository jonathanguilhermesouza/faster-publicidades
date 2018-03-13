using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class ControlLoanMap : EntityTypeConfiguration<ControlLoan>
    {
        public ControlLoanMap(){

            ToTable("ControlsLoan", "FasterAdministration");
            
            HasKey(a => a.IdControlLoan);

            HasRequired(a => a.Company)
                .WithMany(a => a.ListControlLoan);

            HasRequired(a => a.Equipment)
                .WithMany(a => a.ListControlLoan);
            
            Property(a => a.DateLocation);

            Property(a => a.DateEndLocation);

            Property(a => a.Note)
                .HasMaxLength(255)
                .IsRequired();
            /*HasMany(a => a.ListEquipment)
                .WithMany(a => a.ListControlLoan)
                .Map(a => {
                    a.MapLeftKey("ControlsLoan_IdControlLoan");
                    a.MapRightKey("Equipments_IdEquipment");
                    a.ToTable("ControlsLoanEquipments","FasterAdministration");
                });*/
        }
    }
}

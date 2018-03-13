using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class ContractMap : EntityTypeConfiguration<Contract>
    {
        public ContractMap()
        {
            ToTable("Contracts", "FasterAdministration");

            HasKey(c => c.IdContract);

            HasRequired(c => c.Company)
                .WithMany(c => c.ListContract);

            //HasRequired(c => c.Plan)
            //  .WithMany(c => c.ListContract);

            HasRequired(c => c.DayOfMonth)
              .WithMany(c => c.ListContract);

            Property(c => c.StatusContract);

            Property(c => c.Note)
                .HasMaxLength(255);

            Property(c => c.DateStart);

            Property(c => c.DateEnd);

        }

    }
}

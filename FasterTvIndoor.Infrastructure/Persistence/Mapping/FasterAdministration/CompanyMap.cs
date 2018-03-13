using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {

            ToTable("Companies", "FasterAdministration");
            
            HasKey(a => a.IdCompany);          

            Property(a => a.CompanyName)
                .HasMaxLength(100)
                .IsRequired();

            Property(a => a.FantasyName)
                .HasMaxLength(100)
                .IsRequired();

            Property(a => a.StateInscription)
                .HasMaxLength(7);

            Property(a => a.Cnpj)
                .HasMaxLength(14)
                .IsRequired();

            Property(a => a.Email)
                .HasMaxLength(50)
                .IsRequired();            

            Property(a => a.DateRegister);

            Property(a => a.HaveContract);

        }

    }
}

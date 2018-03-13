using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class PhoneCompanyMap : EntityTypeConfiguration<PhoneCompany>
    {
        public PhoneCompanyMap()
        {

            ToTable("PhonesCompany", "FasterAdministration");

            HasKey(a => a.IdPhoneCompany);

            Property(a => a.Number)
                .HasMaxLength(15)
                .IsRequired();

            HasRequired(a => a.Company)
                .WithMany(a => a.ListPhonesCompany);

        }
    }
}

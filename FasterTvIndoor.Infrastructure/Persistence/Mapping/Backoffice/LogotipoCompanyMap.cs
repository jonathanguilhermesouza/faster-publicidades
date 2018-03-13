using FasterTvIndoor.Domain.BackOffice.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.Backoffice
{
    public class LogotipoCompanyMap : EntityTypeConfiguration<LogotipoCompany>
    {
        public LogotipoCompanyMap()
        {

            ToTable("LogotiposCompany", "Backoffice");
            
            HasKey(a => a.IdLogotipoCompany);

            Property(a => a.PathImage)
                .HasMaxLength(200);

            HasRequired(a => a.Company)
                .WithMany(a => a.ListLogotipoCompany);
        }
    }
}

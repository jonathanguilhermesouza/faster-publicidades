using FasterTvIndoor.Domain.BackOffice.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.Backoffice
{
    public class EmployeeCompanyMap : EntityTypeConfiguration<EmployeeCompany>
    {
        public EmployeeCompanyMap()
        {

            ToTable("EmployeesCompany", "Backoffice");

            HasKey(a => a.IdEmployeeCompany);

            Property(a => a.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            HasRequired(a => a.SectorCompany)
                .WithMany(a => a.ListEmployedCompany);

            HasRequired(a => a.Company)
                .WithMany(a => a.ListEmployedCompany);
            
            HasRequired(a => a.User)
                .WithMany(a => a.ListEmployedCompany);
            
        }
    }
}

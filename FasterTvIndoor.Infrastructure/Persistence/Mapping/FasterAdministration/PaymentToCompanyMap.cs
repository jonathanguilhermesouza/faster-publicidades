using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class PaymentToCompanyMap : EntityTypeConfiguration<PaymentToCompany>
    {
        public PaymentToCompanyMap()
        {
            ToTable("PaymentsToCompany","FasterAdministration");

            HasKey(a => a.IdPaymentToCompany);

            HasRequired(a => a.Company)
                .WithMany(a => a.ListPaymentToCompany);

            Property(a => a.DatePayment)
                .IsRequired();

            Property(a => a.Description)
                .HasMaxLength(255);

            Property(a => a.Value)
                .HasPrecision(10,2);

        }
    }
}

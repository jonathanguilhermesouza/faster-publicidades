using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class AddressCompanyMap : EntityTypeConfiguration<AddressCompany>
    {
        public AddressCompanyMap()
        {

            ToTable("AddressesCompany", "FasterAdministration");
            
            HasKey(a => a.IdAddressCompany);

            HasRequired(a => a.Company)
                .WithMany(a => a.ListAddressCompany);

            Property(a => a.Cep)
                .HasMaxLength(9)
                .IsRequired();

            Property(a => a.Logradouro)
                .HasMaxLength(50)
                .IsRequired();

            Property(a => a.Complemento)
                .HasMaxLength(255);

            Property(a => a.Bairro)
                .HasMaxLength(50)
                .IsRequired();

            Property(a => a.Localidade)
                .HasMaxLength(50)
                .IsRequired();

            Property(a => a.Uf)
                .HasMaxLength(2)
                .IsRequired();

            Property(a => a.Ibge)
                .HasMaxLength(7)
                .IsRequired();

            Property(a => a.Gia)
                .HasMaxLength(5);

            Property(a => a.Number)
                .HasMaxLength(10)
                .IsRequired();

            Property(a => a.Reference)
                .HasMaxLength(255);

            Property(a => a.Region)
                .IsRequired();
            
        }
    }
}

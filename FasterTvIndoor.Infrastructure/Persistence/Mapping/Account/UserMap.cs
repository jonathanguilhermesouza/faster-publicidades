using FasterTvIndoor.Domain.Account.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.Account
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {

            ToTable("Users", "Account");

            HasKey(a => a.IdUser);

            //Usar  Property(a => a.IdUser)..HasDatabaseGeneratedOption(databaseGeneratedOption.Identity); -- para o sql gerar o guid
            Property(a => a.Name)                
                .HasMaxLength(50);

            Property(a => a.LastName)
                .HasMaxLength(50);

            Property(a => a.Email)
                .HasMaxLength(100);

            Property(a => a.Password)
                .HasMaxLength(50);

        }
    }
}

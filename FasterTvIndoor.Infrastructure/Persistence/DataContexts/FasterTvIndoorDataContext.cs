using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.BackOffice.Entities;
using FasterTvIndoor.Domain.Client.Entities;
using FasterTvIndoor.Domain.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.Account;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.Backoffice;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.Client;
using FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration;
using RedeFaster.Infrastructure.Persistence.Mapping.Client;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FasterTvIndoor.Infrastructure.Persistence.DataContexts
{
    public class FasterTvIndoorDataContext : DbContext 
    {
        public FasterTvIndoorDataContext()
            : base("FasterIndoor")
        {
                      
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<ProfileUser> ProfileUser { get; set; }
        public DbSet<AddressCompany> AddressCompany { get; set; }
        public DbSet<PhoneCompany> PhoneCompany { get; set; }
        public DbSet<EmployeeCompany> EmployeeCompany { get; set; }
        public DbSet<SectorCompany> SectorCompany { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<TypeEquipment> TypeEquipment { get; set; }
        public DbSet<ControlLoan> ControlLoan { get; set; }
        public DbSet<CategoryVideo> CategoryVideo { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<TypeVideo> TypeVideo { get; set; }
        public DbSet<VideoEquipment> VideoEquipment { get; set; }
        public DbSet<TimeVideo> TimeVideo { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<AddressUser> AddressUser { get; set; }
        public DbSet<PhoneUser> PhoneUser { get; set; }
        public DbSet<Year> Year { get; set; }
        public DbSet<DayOfMonth> DayOfMonth { get; set; }
        public DbSet<PaymentToCompany> PaymentToCompany { get; set; }
        public DbSet<HistoryEquipment> HistoryEquipment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar")); 


            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new ContractMap());
            modelBuilder.Configurations.Add(new ControlLoanMap());
            modelBuilder.Configurations.Add(new EquipmentMap());
            modelBuilder.Configurations.Add(new ProfileUserMap());
            modelBuilder.Configurations.Add(new SectorCompanyMap());
            modelBuilder.Configurations.Add(new ClaimsMap());
            modelBuilder.Configurations.Add(new AddressCompanyMap());
            modelBuilder.Configurations.Add(new EmployeeCompanyMap());
            modelBuilder.Configurations.Add(new LogotipoCompanyMap());
            modelBuilder.Configurations.Add(new PhoneCompanyMap());
            modelBuilder.Configurations.Add(new TypeEquipmentMap());
            modelBuilder.Configurations.Add(new CategoryVideoMap());
            modelBuilder.Configurations.Add(new VideoMap());
            modelBuilder.Configurations.Add(new TypeVideoMap());
            modelBuilder.Configurations.Add(new TimeVideoMap());
            modelBuilder.Configurations.Add(new VideoEquipmentMap());
            modelBuilder.Configurations.Add(new PlanMap());
            modelBuilder.Configurations.Add(new AddressUserMap());
            modelBuilder.Configurations.Add(new PhoneUserMap());
            modelBuilder.Configurations.Add(new AccountCurrentMap());
            modelBuilder.Configurations.Add(new YearMap());
            modelBuilder.Configurations.Add(new DayOfMonthMap());
            modelBuilder.Configurations.Add(new PaymentToCompanyMap());
            modelBuilder.Configurations.Add(new HistoryEquipmentMap()); 

        }
    }
}

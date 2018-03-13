using FasterTvIndoor.ApplicationService.Services.Account;
using FasterTvIndoor.ApplicationService.Services.BackOffice;
using FasterTvIndoor.ApplicationService.Services.Client;
using FasterTvIndoor.ApplicationService.Services.FasterAdministration;
using FasterTvIndoor.Domain.Account.Repositories;
using FasterTvIndoor.Domain.Account.Services;
using FasterTvIndoor.Domain.BackOffice.Repositories;
using FasterTvIndoor.Domain.BackOffice.Services;
using FasterTvIndoor.Domain.Client.Repositories;
using FasterTvIndoor.Domain.Client.Services;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using FasterTvIndoor.Infrastructure.Repositories.Account;
using FasterTvIndoor.Infrastructure.Repositories.BackOffice;
using FasterTvIndoor.Infrastructure.Repositories.Client;
using FasterTvIndoor.Infrastructure.Repositories.FasterAdministration;
using FasterTvIndoor.SharedKernel;
using FasterTvIndoor.SharedKernel.Events;
using Microsoft.Practices.Unity;

namespace FasterTvIndoor.CrossCuting
{
    public class DependencyRegister
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve gera uma nova instância.
        /// ContainerControlledLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>  
        public static void Register(UnityContainer container)
        {
            container.RegisterType<FasterTvIndoorDataContext, FasterTvIndoorDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusCompanyRepository, StatusCompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClassificationCompanyRepository, ClassificationCompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhoneCompanyRepository, PhoneCompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddressCompanyRepository, AddressCompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompanyRepository, CompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeCompanyRepository, EmployeeCompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISectorCompanyRepository, SectorCompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProfileUserRepository, ProfileUserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusEquipmentRepository, StatusEquipmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEquipmentRepository, EquipmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITypeEquipmentRepository, TypeEquipmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IControlLoanRepository, ControlLoanRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusControlLoanRepository, StatusControlLoanRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusUserRepository, StatusUserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContractRepository, ContractRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusContractRepository, StatusContractRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusContractRepository, StatusContractRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryVideoRepository, CategoryVideoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITypeVideoRepository, TypeVideoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IVideoRepository, VideoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusVideoRepository, StatusVideoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IVideoEquipmentRepository, VideoEquipmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITimeVideoRepository, TimeVideoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlanRepository, PlanRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISizeCompanyRepository, SizeCompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddressUserRepository, AddressUserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhoneUserRepository, PhoneUserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBalanceRepository, BalanceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDayOfMonthRepository, DayOfMonthRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMonthOfYearRepository, MonthOfYearRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IYearRepository, YearRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPaymentToCompanyRepository, PaymentToCompanyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IHistoryEquipmentRepository, HistoryEquipmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionRepository, ActionRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IStatusCompanyApplicationService, StatusCompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClassificationCompanyApplicationService, ClassificationCompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhoneCompanyApplicationService, PhoneCompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddressCompanyApplicationService, AddressCompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserApplicationService, UserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompanyApplicationService, CompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeCompanyApplicationService, EmployeeCompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISectorCompanyApplicationService, SectorCompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProfileUserApplicationService, ProfileUserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusEquipmentApplicationService, StatusEquipmentApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEquipmentApplicationService, EquipmentApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITypeEquipmentApplicationService, TypeEquipmentApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IControlLoanApplicationService, ControlLoanApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusControlLoanApplicationService, StatusControlLoanApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusUserApplicationService, StatusUserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IContractApplicationService, ContractApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusContractApplicationService, StatusContractApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITypeVideoApplicationService, TypeVideoApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryVideoApplicationService, CategoryVideoApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IVideoApplicationService, VideoApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusVideoApplicationService, StatusVideoApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IVideoEquipmentApplicationService, VideoEquipmentApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITimeVideoApplicationService, TimeVideoApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlanApplicationService, PlanApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISizeCompanyApplicationService, SizeCompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddressUserApplicationService, AddressUserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhoneUserApplicationService, PhoneUserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBalanceApplicationService, BalanceApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDayOfMonthApplicationService, DayOfMonthApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMonthOfYearApplicationService, MonthOfYearApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IYearApplicationService, YearApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPaymentToCompanyApplicationService, PaymentToCompanyApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPaymentToCompanyComplementApplicationService, PaymentToCompanyComplementApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IHistoryEquipmentApplicationService, HistoryEquipmentApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionApplicationService, ActionApplicationService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());

        }
    }
}

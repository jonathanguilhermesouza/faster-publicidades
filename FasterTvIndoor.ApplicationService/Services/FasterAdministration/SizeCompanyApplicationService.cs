using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class SizeCompanyApplicationService : ApplicationService, ISizeCompanyApplicationService
    {
        private ISizeCompanyRepository _repository;
        public SizeCompanyApplicationService(ISizeCompanyRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<SizeCompany> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

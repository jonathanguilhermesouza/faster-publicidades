using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class StatusCompanyApplicationService : ApplicationService, IStatusCompanyApplicationService
    {
        private IStatusCompanyRepository _repository;
        public StatusCompanyApplicationService(IStatusCompanyRepository repository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _repository = repository;
        }

        public List<StatusCompany> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class StatusContractApplicationService : ApplicationService, IStatusContractApplicationService
    {
        private IStatusContractRepository _repository;

        public StatusContractApplicationService(IStatusContractRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<StatusContract> GetAll()
        {
            return _repository.GetAll();
        }

    }
}

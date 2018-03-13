using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class StatusVideoApplicationService : ApplicationService, IStatusVideoApplicationService
    {
        private IStatusVideoRepository _repository;
        public StatusVideoApplicationService(IStatusVideoRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository; 
        }
        public List<StatusVideo> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

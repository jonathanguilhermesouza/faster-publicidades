using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class StatusEquipmentApplicationService : ApplicationService, IStatusEquipmentApplicationService
    {
        private IStatusEquipmentRepository _repository;
        public StatusEquipmentApplicationService(IStatusEquipmentRepository repository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _repository = repository;
        }

        public List<StatusEquipment> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

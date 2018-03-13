using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class ActionApplicationService : ApplicationService, IActionApplicationService
    {
        private IActionRepository _repository;
        public ActionApplicationService(IActionRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<_Action> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
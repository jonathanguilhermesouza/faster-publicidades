using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class MonthOfYearApplicationService : ApplicationService, IMonthOfYearApplicationService
    {
        private IMonthOfYearRepository _repository;
        public MonthOfYearApplicationService(IMonthOfYearRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }
        public List<MonthOfYear> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

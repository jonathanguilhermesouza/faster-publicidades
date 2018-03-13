using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class StatusControlLoanApplicationService : ApplicationService, IStatusControlLoanApplicationService
    {
        private IStatusControlLoanRepository _repository;
        public StatusControlLoanApplicationService(IStatusControlLoanRepository repository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _repository = repository;
        }

        public List<StatusControlLoan> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

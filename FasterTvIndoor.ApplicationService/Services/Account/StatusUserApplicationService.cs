using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.Account.Repositories;
using FasterTvIndoor.Domain.Account.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.Account
{
    public class StatusUserApplicationService : ApplicationService, IStatusUserApplicationService
    {

        private IStatusUserRepository _repository;
        public StatusUserApplicationService(IStatusUserRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<StatusUser> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class ClassificationCompanyApplicationService : ApplicationService, IClassificationCompanyApplicationService
    {
        private IClassificationCompanyRepository _repository;
        public ClassificationCompanyApplicationService(IClassificationCompanyRepository repository, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _repository = repository;
        }

        public List<ClassificationCompany> GetAll()
        {
            return _repository.GetAll(); ;
        }
    }
}

using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Commands.YearCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class YearApplicationService : ApplicationService, IYearApplicationService
    {
        private IYearRepository _repository;
        public YearApplicationService(IYearRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }
        public Year Create(CreateYearCommand command)
        {
            var year = new Year(command.Number);
            year.Create();
            _repository.Create(year);

            if (Commit())
                return year;

            return null;
        }

        public List<Year> GetAll()
        {
            return _repository.GetAll();
        }

        public Year GetById(int id)
        {
            return _repository.GetById(id);
        }
        
        public Year Update(UpdateYearCommand command)
        {
            var year = _repository.GetById(command.IdYear);
            year.Update(command);
            _repository.Update(year);

            if (Commit())
                return year;

            return null;
        }
    }
}

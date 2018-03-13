using FasterTvIndoor.Domain.FasterAdministration.Commands.DayOfMonth;
using FasterTvIndoor.Domain.FasterAdministration.Commands.TimeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class DayOfMonthApplicationService : ApplicationService, IDayOfMonthApplicationService
    {
        private IDayOfMonthRepository _repository;
        public DayOfMonthApplicationService(IDayOfMonthRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<DayOfMonth> GetAll()
        {
            return _repository.GetAll();
        }

        public DayOfMonth GetById(int id)
        {
            return _repository.GetById(id);
        }

        public DayOfMonth Create(CreateDayOfMonthCommand command)
        {
            var day = new DayOfMonth(command.Day);
            day.Create();
            _repository.Create(day);

            if (Commit())
                return day;

            return null;
        }

        public DayOfMonth Update(UpdateDayOfMonthCommand command)
        {
            var day = _repository.GetById(command.Day);
            day.Update(command);
            _repository.Update(day);

            if (Commit())
                return day;

            return null;
        }

        public DayOfMonth Delete()
        {
            return null;
        }
    }
}

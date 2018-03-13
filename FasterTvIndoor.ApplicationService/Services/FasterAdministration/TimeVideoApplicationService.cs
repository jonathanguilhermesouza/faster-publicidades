using FasterTvIndoor.Domain.FasterAdministration.Commands.TimeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class TimeVideoApplicationService : ApplicationService,ITimeVideoApplicationService
    {
        private ITimeVideoRepository _repository;
        public TimeVideoApplicationService(ITimeVideoRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<TimeVideo> GetAll()
        {
            return _repository.GetAll();
        }

        public List<TimeVideo> GetByRange(int skip, int take)
        {
            return _repository.GetByRange(skip, take);
        }

        public TimeVideo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TimeVideo Create(CreateTimeVideoCommand command)
        {
            var time = new TimeVideo(command.Time);
            time.Create();
            _repository.Create(time);
            
            if (Commit())
                return time;

            return null;
        }

        public TimeVideo Update(UpdateTimeVideoCommand command)
        {
            var time = _repository.GetById(command.IdTimeVideo);
            time.Update(command);
            _repository.Update(time);
            
            if (Commit())
                return time;

            return null;
        }

        public TimeVideo Delete()
        {
            /*var equipment = _repository.GetById(command.IdTimeVideo);
            _repository.Delete(equipment);
            
            if (Commit())
                return equipment;
            */
            return null;
        }

        public int GetCount()
        {
            return _repository.GetCount();
        }
    }
}

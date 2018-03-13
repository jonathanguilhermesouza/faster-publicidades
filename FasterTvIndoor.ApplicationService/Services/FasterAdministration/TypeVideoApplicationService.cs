using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class TypeVideoApplicationService : ApplicationService, ITypeVideoApplicationService
    {
        private ITypeVideoRepository _repository;
        public TypeVideoApplicationService(ITypeVideoRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<TypeVideo> GetAll()
        {
            return _repository.GetAll();
        }

        public List<TypeVideo> GetByRange(int skip, int take, string word)
        {
            return _repository.GetByRange(skip, take, word);
        }

        public TypeVideo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TypeVideo Create(CreateTypeVideoCommand command)
        {
            var typeVideo = new TypeVideo(command.Type);
            typeVideo.Create();
            _repository.Create(typeVideo);

            if (Commit())
                return typeVideo;

            return null;
        }

        public TypeVideo Update(UpdateTypeVideoCommand command)
        {
            var typeVideo = _repository.GetById(command.IdTypeVideo);
            typeVideo.Update(command);
            _repository.Update(typeVideo);

            if (Commit())
                return typeVideo;

            return null;
        }

        public TypeVideo Delete()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount(string word)
        {
            return _repository.GetCount(word);
        }
    }
}

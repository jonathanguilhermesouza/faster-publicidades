using FasterTvIndoor.Domain.FasterAdministration.Commands.CategoryVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class CategoryVideoApplicationService : ApplicationService, ICategoryVideoApplicationService
    {
        private ICategoryVideoRepository _repository;
        public CategoryVideoApplicationService(ICategoryVideoRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<CategoryVideo> GetAll()
        {
            return _repository.GetAll();
        }

        public List<CategoryVideo> GetByRange(int skip, int take, string word)
        {
            return _repository.GetByRange(skip, take, word);
        }

        public CategoryVideo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public CategoryVideo Create(CreateCategoryVideoCommand command)
        {
            var category = new CategoryVideo(command.Category);
            category.Create();
            _repository.Create(category);

            if (Commit())
                return category;

            return null;
        }

        public CategoryVideo Update(UpdateCategoryVideoCommand command)
        {
            var category = _repository.GetById(command.IdCategoryVideo);
            category.Update(command);
            _repository.Update(category);

            if (Commit())
                return category;

            return null;
        }

        public CategoryVideo Delete()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount(string word)
        {
            return _repository.GetCount(word);
        }
    }
}

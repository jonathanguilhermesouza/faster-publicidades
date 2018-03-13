using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class CategoryVideoRepository : ICategoryVideoRepository
    {
        private FasterTvIndoorDataContext _context;
        public CategoryVideoRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<CategoryVideo> GetAll()
        {
            return _context.CategoryVideo.ToList();
        }

        public List<CategoryVideo> GetByRange(int skip, int take, string word)
        {
            return _context.CategoryVideo
                .Where(CategoryVideoSpecs.GetCategoryVideo(word))
                .OrderBy(x => x.Category)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public CategoryVideo GetById(int id)
        {
            return _context.CategoryVideo
                .SingleOrDefault(x => x.IdCategoryVideo == id);
        }

        public void Create(CategoryVideo category)
        {
            _context.CategoryVideo.Add(category);
        }

        public void Update(CategoryVideo category)
        {
            _context.Entry<CategoryVideo>(category).State = EntityState.Modified;
        }

        public int GetCount(string word)
        {
            return _context.CategoryVideo.Where(CategoryVideoSpecs.GetCategoryVideo(word)).Count();
        }

    }
}

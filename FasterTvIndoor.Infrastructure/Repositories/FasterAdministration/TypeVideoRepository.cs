using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using FasterTvIndoor.Domain.FasterAdministration.Specs;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class TypeVideoRepository : ITypeVideoRepository
    {
        private FasterTvIndoorDataContext _context;
        public TypeVideoRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<TypeVideo> GetAll()
        {
            return _context.TypeVideo.ToList();
        }

        public List<TypeVideo> GetByRange(int skip, int take, string word)
        {
            return _context.TypeVideo
                .Where(TypeVideoSpecs.GetTypeVideo(word))
                .OrderBy(x => x.Type)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public TypeVideo GetById(int id)
        {
            return _context.TypeVideo
                .SingleOrDefault(x => x.IdTypeVideo == id);
        }

        public void Create(TypeVideo type)
        {
            _context.TypeVideo.Add(type);
        }

        public void Update(TypeVideo type)
        {
            _context.Entry<TypeVideo>(type).State = EntityState.Modified;
        }

        public int GetCount(string word)
        {
            return _context.TypeVideo.Where(TypeVideoSpecs.GetTypeVideo(word)).Count();
        }
    }
}

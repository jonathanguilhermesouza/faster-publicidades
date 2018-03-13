using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class TimeVideoRepository: ITimeVideoRepository
    {
        private FasterTvIndoorDataContext _context;
        public TimeVideoRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<TimeVideo> GetAll()
        {
            return _context.TimeVideo.ToList();
        }

        public List<TimeVideo> GetByRange(int skip, int take, string word)
        {
            return _context.TimeVideo
                .Where(TimeVideoSpecs.GetTimeVideo(word))
                .OrderBy(x => x.Time)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public TimeVideo GetById(int id)
        {
            return _context.TimeVideo
                .SingleOrDefault(x => x.IdTimeVideo == id);
        }

        public void Create(TimeVideo timeVideo)
        {
            _context.TimeVideo.Add(timeVideo);
        }

        public void Update(TimeVideo timeVideo)
        {
            _context.Entry<TimeVideo>(timeVideo).State = EntityState.Modified;
        }

        public int GetCount(string word)
        {
            return _context.TimeVideo.Where(TimeVideoSpecs.GetTimeVideo(word)).Count();
        }


        public List<TimeVideo> GetByRange(int skip, int take)
        {
            return _context.TimeVideo
                .OrderBy(x => x.Time)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public void Delete(TimeVideo timeVideo)
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            return _context.TimeVideo.Count();
        }
    }
}

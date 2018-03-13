using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class VideoRepository : IVideoRepository
    {
        private FasterTvIndoorDataContext _context;

        public VideoRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public List<Video> GetAll()
        {
            return _context.Video.ToList();
        }

        public List<Video> GetByRange(int skip, int take, string word, EStatusVideo status)
        {
            return _context.Video
                .Include("Company")
                .Include("CategoryVideo")
                .Include("TypeVideo")
                .Include("TimeVideo")
                .Include("Plan")
                .Include("ListVideoEquipment")
                .Where(VideoSpecs.GetVideo(word, status))
                .OrderBy(x => x.DateRegister)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public Video GetById(int id)
        {
            return _context.Video
                .Include("Company")
                .Include("CategoryVideo")
                .Include("TypeVideo")
                .Include("TimeVideo")
                .Include("Plan")
                .Include("ListVideoEquipment")
                .Include("ListVideoEquipment.Equipment")
                .Include("ListVideoEquipment.Equipment.ListControlLoan.Company")
                .SingleOrDefault(x => x.IdVideo == id);
        }

        public void Create(Video video)
        {
            _context.Video.Add(video);
        }

        public void Update(Video video)
        {
            _context.Entry<Video>(video).State = EntityState.Modified;
        }

        public int GetCount(string word, EStatusVideo status)
        {
            return _context.Video.Where(VideoSpecs.GetVideo(word, status)).Count();
        }

        public List<Video> GetByRangeCompany(int skip, int take, int id, EStatusVideo status)
        {
            return _context.Video
                .Include("Company")
                .Include("CategoryVideo")
                .Include("TypeVideo")
                .Include("TimeVideo")
                .Include("ListVideoEquipment")
                .Where(VideoSpecs.GetVideoCompany(id, status))
                .OrderBy(x => x.DateRegister)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public int GetCountCompany(int id, EStatusVideo status)
        {
            return _context.Video.Where(VideoSpecs.GetVideoCompany(id, status)).Count();
        }

        public void Delete(Video video)
        {
            _context.Entry<Video>(video).State = System.Data.Entity.EntityState.Modified;
        }
    }
}

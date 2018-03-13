using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class VideoEquipmentRepository : IVideoEquipmentRepository
    {
        private FasterTvIndoorDataContext _context;

        public VideoEquipmentRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }
        public List<VideoEquipment> GetAll()
        {
            return _context
                    .VideoEquipment
                    .Include("Equipment")
                    .Include("Video")
                    .Include("Video.Plan")
                    .Include("Video.Company")
                    //.GroupBy(x => new { x.IdVideo})
                    //.Select(g => g.FirstOrDefault())
                    .ToList();
        }

        public VideoEquipment GetIdVideoEquipment(int equipment, int video)
        {
            return _context.VideoEquipment
                    .SingleOrDefault(VideoEquipmentSpecs.GetIdVideoEquipment(equipment, video));
        }

        public List<VideoEquipment> GetByRange(int skip, int take, string word)
        {
            return _context.VideoEquipment
                .Include("Equipment")
                .Include("Video")
                .Where(VideoEquipmentSpecs.GetVideoEquipment(word))
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public VideoEquipment GetById(int id)
        {
            return _context.VideoEquipment
                .Include("Equipment")
                .Include("Video")
                .SingleOrDefault(x => x.IdVideoEquipment == id);
        }

        public List<VideoEquipment> GetByIdEquipment(int id)
        {
            return _context.VideoEquipment
                //.Include("Equipment")
                .Include("Video")
                .Include("Video.Company")
                .Include("Video.TimeVideo")
                .Include("Video.TypeVideo")
                .Include("Equipment")
                .Where(x => x.IdEquipment == id).ToList();
        }

        public void Create(VideoEquipment videoEquipment)
        {
            _context.VideoEquipment.Add(videoEquipment);
        }

        public void Update(VideoEquipment videoEquipment)
        {
            _context.Entry<VideoEquipment>(videoEquipment).State = EntityState.Modified;
        }

        public void Delete(VideoEquipment videoEquipment)
        {
            //_context.VideoEquipment.Remove(videoEquipment);
            _context.Entry<VideoEquipment>(videoEquipment).State = EntityState.Modified;
        }

        public int GetCount(string word)
        {
            return _context.VideoEquipment
                .Include("Equipment")
                .Include("Video")
                .Where(VideoEquipmentSpecs.GetVideoEquipment(word)).Count();
        }

        public decimal GetTotalVideoByEquipment(int idVideo)
        {
            return _context.VideoEquipment
                .Include("Equipment")
                .Include("Video")
                .Where(VideoEquipmentSpecs.GetTotalByEquipment(idVideo)).Sum(x => x.Video.Plan.ValueEquipmentMain);//verificar aqui a lógica
        }

        public int GetVideoCountByEquipment(int idVideo)
        {
            return _context.VideoEquipment
                .Where(VideoEquipmentSpecs.GetTotalByEquipment(idVideo)).Count();// não estou usando ***verificar
        }

        public int GetVideoCountByCompany(int id)
        {
            return _context.VideoEquipment
                .Where(VideoEquipmentSpecs.GetVideoByCompany(id)).Count();
        }

        public List<VideoEquipment> GetByRange(int skip, int take, int id)
        {
            return _context.VideoEquipment
                .Include("Equipment")
                .Include("Video")
                .Include("Video.Plan")
                .Include("Video.Company")
                .Where(VideoEquipmentSpecs.GetVideoEquipmentByCompany(id))
                .OrderBy(x => x.IdVideoEquipment)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public List<VideoEquipment> GetByRangeCompany(int skip, int take, int id)
        {
            return _context.VideoEquipment
                .Include("Equipment")
                .Include("Video")
                .Include("Video.Plan")
                .Include("Video.Company")
                .Include("ControlLoan.Company")
                .Where(VideoEquipmentSpecs.GetVideoByCompany(id))
                .OrderBy(x => x.IdVideoEquipment)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public List<VideoEquipment> GetAllByVideo(int video)
        {
            return _context.VideoEquipment
                .Include("Equipment")
                .Include("Video")
                .Include("Video.Plan")
                .Include("Video.Company")
                .Include("ControlLoan.Company")
                .Where(VideoEquipmentSpecs.GetByVideo(video)).ToList();

        }

        public int GetCount(string word, int idCompany)
        {
            return _context.VideoEquipment.Where(a => a.ControlLoan.IdCompany == idCompany && a.Status == EStatusVideoEquipment.Ativo && a.Video.Status == EStatusVideo.Ativo).Count();
        }

        public void Delete(ICollection<VideoEquipment> listVideoEquipment)
        {
            foreach (var videoEquipment in listVideoEquipment)
            {
                _context.Entry<VideoEquipment>(videoEquipment).State = EntityState.Modified;
            }
        }

        public VideoEquipment GetById(int idEquipment, int idVideo, int idControlLoan)
        {
            return _context.VideoEquipment.Where(a => a.IdEquipment == idEquipment && a.IdVideo == idVideo && a.IdControlLoan == idControlLoan).FirstOrDefault();
        }

        public List<VideoEquipment> GetByStatus(EStatusVideoEquipment status)
        {
            return _context.VideoEquipment
                .Include("Video")
                .Where(a => a.Status == status && (a.Video.DateEnd == DateTime.Now || a.Video.DateEnd < DateTime.Now)).ToList();
        }

        public void UpdateStatusListVideo(ICollection<VideoEquipment> listVideoEquipment)
        {
            foreach (var videoEquipment in listVideoEquipment)
            {
                _context.Entry<VideoEquipment>(videoEquipment).State = EntityState.Modified;
            }
        }
    }
}

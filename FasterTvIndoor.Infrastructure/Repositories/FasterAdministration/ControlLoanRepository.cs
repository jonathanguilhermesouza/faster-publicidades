using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class ControlLoanRepository : IControlLoanRepository
    {
        private FasterTvIndoorDataContext _context;
        public ControlLoanRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public List<ControlLoan> GetAll()
        {
            return _context.ControlLoan.ToList();
        }

        public List<ControlLoan> GetAllControlLoanEquipmentByVideo(int idVideo,int idTypeEquipment, EStatusControlLoan status)
        {
            return _context.ControlLoan
                .Include("Company")
                .Include("Equipment")
                .Include("Equipment.TypeEquipment")
                .Where(ControlLoanSpecs.GetEquipmentControlLoan(idTypeEquipment, idVideo, status))
                .OrderBy(x => x.IdControlLoan).ToList();
        }

        public List<ControlLoan> GetAllControlLoanEquipment(int idTypeEquipment, EStatusControlLoan status)
        {
            return _context.ControlLoan
                .Include("Company")
                .Include("Equipment")
                .Include("Equipment.TypeEquipment")
                .Where(ControlLoanSpecs.GetEquipmentControlLoan(idTypeEquipment, status))
                .OrderBy(x => x.IdControlLoan).ToList();
        }

        public List<ControlLoan> GetByRange(int skip, int take, string word, EStatusControlLoan status)
        {
            return _context.ControlLoan
                .Include("Company")
                .Include("Equipment")
                .Include("Equipment.TypeEquipment")
                .Where(ControlLoanSpecs.GetSearchControlLoan(word, status))
                .OrderBy(x => x.IdControlLoan).Skip((skip - 1) * take).Take(take).ToList();
        }

        public ControlLoan GetById(int id)
        {
            return _context.ControlLoan
                .Include("Company")
                .Include("Equipment")
                .Include("Equipment.TypeEquipment")
                .SingleOrDefault(x => x.IdControlLoan == id);
        }

        public void Create(ControlLoan controlLoan)
        {
            _context.ControlLoan.Add(controlLoan);
        }

        public void Update(ControlLoan controlLoan)
        {
            _context.Entry<ControlLoan>(controlLoan).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(ControlLoan controlLoan)
        {
            _context.Entry<ControlLoan>(controlLoan).State = System.Data.Entity.EntityState.Modified;
        }

        public int GetCount(string word, EStatusControlLoan status)
        {
            return _context.ControlLoan.Where(ControlLoanSpecs.GetSearchControlLoan(word,status)).Count();
        }

        public ControlLoan GetByIdCompany(int id)
        {
            return _context.ControlLoan
                .Include("Company")
                .Include("Equipment")
                .Include("Equipment.TypeEquipment")
                .Where(x => x.IdCompany == id)
                .OrderByDescending(x => x.IdControlLoan).Skip(1).Take(1)
                .SingleOrDefault();
                
        }
    }
}

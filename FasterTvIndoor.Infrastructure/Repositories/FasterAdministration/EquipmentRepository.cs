using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private FasterTvIndoorDataContext _context;

        public EquipmentRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public List<Equipment> GetAll()
        {
            return _context.Equipment.ToList();
        }

        public List<Equipment> GetAllEquipmentControlLoan(string word, EStatusEquipment statusEquipment, EStatusControlLoan statusControlLoan)
        {

            List<Equipment> listEquipmentAvailable = new List<Equipment>();


            List<ControlLoan> ControlLoan = (List<ControlLoan>)_context.ControlLoan.Where(ControlLoanSpecs.GetControlLoan(statusControlLoan)).ToList();
            List<Equipment> Equipment = _context.Equipment.Where(EquipmentSpecs.GetEquipment(word, statusEquipment)).ToList();

            var joined = ControlLoan.Join(Equipment, controlLoan => controlLoan.IdEquipment, equipment => equipment.IdEquipment, (Person, PersoneType) => new { Name = Person.IdEquipment, TypeID = PersoneType.IdEquipment });

            foreach (var equi in Equipment)
            {
                foreach (var cont in ControlLoan)
	                {
                        if (cont.IdEquipment == equi.IdEquipment)
                        {
                            listEquipmentAvailable.Add(equi);
                        }
	                }
            }



            //joined.Where(a=>a.Name);
            //var result = _context.Equipment.Join(_context.ControlLoan,)
            
                //.Include("TypeEquipment")
                
                //.Where(EquipmentSpecs.GetEquipment(word, status))
                //.OrderBy(x => x.Patrimony).ToList();

            return listEquipmentAvailable;
        }

        public List<Equipment> GetByRange(int skip, int take, string word, EStatusEquipment status)
        {
            return _context
                .Equipment
                .Include("TypeEquipment")
                .Where(EquipmentSpecs.GetEquipment(word, status))
                .OrderBy(x => x.Patrimony).Skip((skip - 1) * take).Take(take).ToList();
        }

        public Equipment GetById(int id)
        {
            return _context
                .Equipment
                .Include("ListControlLoan")
                .SingleOrDefault(x => x.IdEquipment == id);               
        }

        public void Create(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
        }

        public void Update(Equipment equipment)
        {
            _context.Entry<Equipment>(equipment).State = EntityState.Modified;
        }

        public void Delete(Equipment equipment)
        {
            _context.Entry<Equipment>(equipment).State = EntityState.Modified;
        }

        public int GetCount(string word, EStatusEquipment status)
        {
            return _context
                .Equipment
                .Where(EquipmentSpecs.GetEquipment(word, status))
                .Count();
        }
    }
}

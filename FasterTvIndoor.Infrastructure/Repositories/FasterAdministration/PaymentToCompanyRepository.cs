using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Linq;
using FasterTvIndoor.Domain.FasterAdministration.Specs;
using System.Data.Entity;
using System;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class PaymentToCompanyRepository : IPaymentToCompanyRepository
    {
        private FasterTvIndoorDataContext _context;
        public PaymentToCompanyRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public void Create(PaymentToCompany payment)
        {
            _context.PaymentToCompany.Add(payment);
        }

        public void Delete(PaymentToCompany payment)
        {
            _context.PaymentToCompany.Remove(payment);
        }

        public List<PaymentToCompany> GetAll()
        {
            return _context
                .PaymentToCompany
                .Include("Company")
                .ToList();
        }

        public PaymentToCompany GetById(int id)
        {
            return _context
                .PaymentToCompany
                .Include("Company")
                .SingleOrDefault(x => x.IdPaymentToCompany == id);
        }

        public PaymentToCompany GetByIdCompany(int id)
        {
            return _context
                .PaymentToCompany
                .Include("Company")
                .SingleOrDefault(x => x.IdCompany == id);
        }

        public List<PaymentToCompany> GetByRange(int skip, int take, string word)
        {
            return _context.PaymentToCompany
                .Where(PaymentToCompanySpecs.GetPaymentToCompany(word))
                .Include("Company")
                .OrderByDescending(x => x.DatePayment)
                .Skip((skip - 1) * take).Take(take).ToList();
        }


        public List<PaymentToCompany> GetByRangeCompany(int skip, int take, int id)
        {
            return _context.PaymentToCompany
                .Where(PaymentToCompanySpecs.GetPaymentToCompany(id))
                .Include("Company")
                .OrderBy(x => x.DatePayment)
                .Skip((skip - 1) * take).Take(take).ToList();
        }

        public int GetCount(string word)
        {
            return _context
                .PaymentToCompany
                .Where(PaymentToCompanySpecs.GetPaymentToCompany(word))
                .Count();
        }

        public int GetCountCompany(int id)
        {
            return _context
               .PaymentToCompany
               .Where(PaymentToCompanySpecs.GetPaymentToCompany(id))
               .Count();
        }

        public void Update(PaymentToCompany payment)
        {
            _context
                .Entry<PaymentToCompany>(payment).State = EntityState.Modified;
        }
    }
}

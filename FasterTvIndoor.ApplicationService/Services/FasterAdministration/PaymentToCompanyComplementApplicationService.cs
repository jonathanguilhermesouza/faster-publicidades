using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using FasterTvIndoor.SharedKernel.Helpers;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class PaymentToCompanyComplementApplicationService : ApplicationService, IPaymentToCompanyComplementApplicationService
    {
        private IPaymentToCompanyRepository _repository;
        List<PaymentToCompany> listPaymentToCompany = new List<PaymentToCompany>();

        public PaymentToCompanyComplementApplicationService(IPaymentToCompanyRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<PaymentToCompanyComplement> GetAll()
        {
            List<PaymentToCompanyComplement> list = new List<PaymentToCompanyComplement>();

            return list;
        }

        public List<PaymentToCompanyComplement> GetByRangeCompany(int skip, int take, int id)
        {
            List<PaymentToCompanyComplement> list = new List<PaymentToCompanyComplement>();
            PaymentToCompanyComplement paymentComplement;

            listPaymentToCompany = _repository.GetByRangeCompany(skip, take, id);


            foreach (var payment in listPaymentToCompany)
            {
                
                paymentComplement = new PaymentToCompanyComplement(payment.IdPaymentToCompany, payment.IdCompany,payment.Value, payment.DatePayment, payment.DatePayment.Day,payment.DatePayment.Year, new ToEnumMonth(payment.DatePayment.Month).ToMonth().ToString());
                list.Add(paymentComplement);
            }


            return list;
        }

    }
}

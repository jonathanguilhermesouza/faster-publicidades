using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IPaymentToCompanyRepository
    {
        List<PaymentToCompany> GetAll();
        List<PaymentToCompany> GetByRange(int skip, int take, string word);
        List<PaymentToCompany> GetByRangeCompany(int skip, int take, int id);
        PaymentToCompany GetById(int id);
        PaymentToCompany GetByIdCompany(int id);
        void Create(PaymentToCompany payment);
        void Update(PaymentToCompany payment);
        int GetCount(string word);
        int GetCountCompany(int id);
        void Delete(PaymentToCompany payment);
    }
}

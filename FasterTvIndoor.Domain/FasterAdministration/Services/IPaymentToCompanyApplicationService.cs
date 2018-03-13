using FasterTvIndoor.Domain.FasterAdministration.Commands.PaymentToCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Services
{
    public interface IPaymentToCompanyApplicationService
    {
        List<PaymentToCompany> GetAll();
        List<PaymentToCompany> GetByRange(int skip, int take, string word);
        List<PaymentToCompany> GetByRangeCompany(int skip, int take, int id);        
        PaymentToCompany GetById(int id);
        PaymentToCompany GetByIdCompany(int id);
        PaymentToCompany Create(CreatePaymentToCompanyCommand command);
        PaymentToCompany Update(UpdatePaymentToCompanyCommand command);
        PaymentToCompany Delete(DeletePaymentToCompanyCommand command);
        int GetCount(string word);
        int GetCountCompany(int id);
    }
}

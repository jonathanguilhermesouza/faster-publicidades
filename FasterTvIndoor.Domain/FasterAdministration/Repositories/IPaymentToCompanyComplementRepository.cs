using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IPaymentToCompanyComplementRepository
    {
        List<PaymentToCompanyComplement> GetAll();
        List<PaymentToCompanyComplement> GetByRangeCompany(int skip, int take, int id);
    }
}

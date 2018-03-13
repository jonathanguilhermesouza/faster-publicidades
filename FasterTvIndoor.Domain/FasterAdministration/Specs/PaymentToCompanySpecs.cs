using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public class PaymentToCompanySpecs
    {
        public static Expression<Func<PaymentToCompany, bool>> GetPaymentToCompany(string word)
        {
            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdPaymentToCompany.Equals(null);

            return x => x.Company.CompanyName.Contains(word) | x.Company.FantasyName.Contains(word);
        }

        public static Expression<Func<PaymentToCompany, bool>> GetPaymentToCompany(int id)
        {
            return x => x.IdCompany == id;
        }
    }
}

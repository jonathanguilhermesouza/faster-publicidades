using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public class ContractSpecs
    {
        public static Expression<Func<Contract, bool>> GetSearchContract(string word, EStatusContract statusContract)
        {
            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdContract.Equals(null) && x.StatusContract == statusContract;

            return x => x.Company.CompanyName.Contains(word) && x.StatusContract == statusContract;
        }
    }
}

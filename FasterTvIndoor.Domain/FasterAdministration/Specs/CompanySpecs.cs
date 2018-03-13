using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public static class CompanySpecs
    {
        public static Expression<Func<Company, bool>> GetCompany(string word, EStatusCompany status)
        {


            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => x.StatusCompany == status;
            else
                return x => x.StatusCompany == status && (x.CompanyName.Contains(word) || x.Cnpj.Contains(word) || x.FantasyName.Contains(word));

        }

    }
}

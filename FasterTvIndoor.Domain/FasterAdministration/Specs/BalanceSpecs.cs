using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public static class BalanceSpecs
    {
        public static Expression<Func<Balance, bool>> GetBalance(string word)
        {

            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdVideo.Equals(null);

            return x => (x.Value.Equals(word));
        }
    }
}

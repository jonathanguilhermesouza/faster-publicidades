using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public class PlanSpecs
    {
        public static Expression<Func<Plan, bool>> GetPlan(string word)
        {

            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdPlan.Equals(null);

            return x => (x.Description.Contains(word));
        }
    }
}

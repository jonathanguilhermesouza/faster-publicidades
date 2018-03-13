using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class MonthOfYearRepository : IMonthOfYearRepository
    {
        public List<MonthOfYear> GetAll()
        {
            MonthOfYear month;
            List<MonthOfYear> listMonthOfYear = new List<MonthOfYear>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EMonthOfYear)))
            {
                month = new MonthOfYear();
                month.Id = i;
                month.Month = item.ToString();

                listMonthOfYear.Add(month);

                i++;
            }

            return listMonthOfYear;
        }
    }
}

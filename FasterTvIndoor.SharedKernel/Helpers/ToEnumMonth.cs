using FasterTvIndoor.SharedKernel.Model;
using System.Collections.Generic;
using System;
using FasterTvIndoor.SharedKernel.Enuns;

namespace FasterTvIndoor.SharedKernel.Helpers
{
    public class ToEnumMonth
    {
        public string monthString;
        public ToEnumMonth(int month)
        {
            listEnumMonth();

            foreach (var item in listEnumMonth())
            {
                if (item.Id == month)
                    monthString = item.Month;
            }

        }

        public string ToMonth()
        {
            return monthString;
        }

        public List<MonthOfYear> listEnumMonth()
        {

            MonthOfYear month;
            List<MonthOfYear> listMonth = new List<MonthOfYear>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EMonthOfYear)))
            {
                month = new MonthOfYear();
                month.Id = i;
                month.Month = item.ToString();

                listMonth.Add(month);

                i++;
            }

            return listMonth;
            
        }
    }
}

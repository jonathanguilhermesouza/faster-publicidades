using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.DayOfMonth
{
    public class UpdateDayOfMonthCommand
    {
        public UpdateDayOfMonthCommand(int idDayOfMonth,int day)
        {
            this.IdDayOfMonth = idDayOfMonth;
            this.Day = day;
        }
        public int IdDayOfMonth { get; set; }
        public int Day { get; set; }
    }
}

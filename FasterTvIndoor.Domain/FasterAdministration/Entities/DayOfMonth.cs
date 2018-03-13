using FasterTvIndoor.Domain.FasterAdministration.Commands.DayOfMonth;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class DayOfMonth
    {
        public DayOfMonth(){}
        public DayOfMonth(int day)
        {
            this.Day = day;
        }
        public int IdDayOfMonth { get; set; }
        public int Day { get; set; }
        public ICollection<Contract> ListContract { get; set; }
        
        public void Create()
        {

        }

        public void Update(UpdateDayOfMonthCommand command)
        {

        }
    }
}

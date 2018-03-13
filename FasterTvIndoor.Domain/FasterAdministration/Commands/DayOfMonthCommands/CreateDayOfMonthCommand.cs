namespace FasterTvIndoor.Domain.FasterAdministration.Commands.DayOfMonth
{
    public class CreateDayOfMonthCommand
    {
        public CreateDayOfMonthCommand(int day)
        {
            this.Day = day;
        }
        public int IdDayOfMonth { get; set; }
        public int Day { get; set; }
    }
}

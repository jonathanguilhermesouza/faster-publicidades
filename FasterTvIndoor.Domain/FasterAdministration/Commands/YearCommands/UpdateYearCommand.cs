namespace FasterTvIndoor.Domain.FasterAdministration.Commands.YearCommands
{
    public class UpdateYearCommand
    {
        public UpdateYearCommand(int idYear,int number)
        {
            this.IdYear = idYear;
            this.Number = number;
        }
        public int IdYear { get; set; }
        public int Number { get; set; }
    }
}

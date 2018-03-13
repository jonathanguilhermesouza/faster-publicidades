namespace FasterTvIndoor.Domain.FasterAdministration.Commands.YearCommands
{
    public class CreateYearCommand
    {
        public CreateYearCommand(int number)
        {
            this.Number = number;
        }
        public int IdYear { get; set; }
        public int Number { get; set; }
    }
}

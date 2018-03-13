
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.SectorCompanyCommands
{
    public class CreateSectorCompanyCommand
    {
        public CreateSectorCompanyCommand(string sector)
        {
            this.Sector = sector;
        }
        public string Sector { get; private set; }
    }
}

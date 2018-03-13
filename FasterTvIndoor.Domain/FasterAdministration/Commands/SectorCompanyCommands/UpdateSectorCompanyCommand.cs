
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.SectorCompanyCommands
{
    public class UpdateSectorCompanyCommand
    {
        public UpdateSectorCompanyCommand(int idSectorCompany, string sector)
        {
            this.IdSectorCompany = idSectorCompany;
            this.Sector = sector;
        }
        public int IdSectorCompany { get; private set; }
        public string Sector { get; private set; }
    }
}

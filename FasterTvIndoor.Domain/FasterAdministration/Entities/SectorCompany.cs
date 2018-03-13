using FasterTvIndoor.Domain.BackOffice.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Commands.SectorCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class SectorCompany
    {
        public SectorCompany(){}
        public SectorCompany(int idSectorCompany,string sector)
        {
            this.IdSectorCompany = idSectorCompany;
            this.Sector = sector;
        }
        public SectorCompany(string sector)
        {
            this.Sector = sector;
        }
        public int IdSectorCompany { get; private set; }
        public string Sector { get; private set; }
        public ICollection<EmployeeCompany> ListEmployedCompany { get; private set; }

        public void Create()
        {
            if (!this.CreateSectorCompanyScopeIsValid())
                return;
        }

        public void Update(UpdateSectorCompanyCommand command)
        {
            if (!this.UpdateSectorCompanyScopeIsValid(command))
                return;

            this.Sector = command.Sector;
            
        }
        
    }
}

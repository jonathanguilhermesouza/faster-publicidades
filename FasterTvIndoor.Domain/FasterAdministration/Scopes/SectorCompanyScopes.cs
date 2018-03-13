using FasterTvIndoor.Domain.FasterAdministration.Commands.SectorCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class SectorCompanyScopes
    {
        public static bool CreateSectorCompanyScopeIsValid(this SectorCompany sector)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(sector.Sector, "O setor é obrigatório")
            );
        }

        public static bool UpdateSectorCompanyScopeIsValid(this SectorCompany sector, UpdateSectorCompanyCommand command)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(command.Sector, "O setor é obrigatório")
            );
        }
        
    }
}

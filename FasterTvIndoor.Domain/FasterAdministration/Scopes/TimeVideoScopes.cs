
using FasterTvIndoor.Domain.FasterAdministration.Commands.TimeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;
namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class TimeVideoScopes
    {
        public static bool CreateTimeVideoScopeIsValid(this TimeVideo timeVideo)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertTrue(!(timeVideo.Time == 0), "O tempo é obrigatório")
                );
        }

        public static bool UpdateTimeVideoScopeIsValid(this TimeVideo timeVideo, UpdateTimeVideoCommand newTimeVideo)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertTrue(!(newTimeVideo.Time == 0), "O tempo é obrigatório")
                );
        }
    }
}

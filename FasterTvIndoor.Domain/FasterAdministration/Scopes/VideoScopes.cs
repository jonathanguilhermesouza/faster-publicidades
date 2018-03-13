using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Scopes
{
    public static class VideoScopes
    {
        public static bool CreateVideoScopeIsValid(this Video video)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(video.Url, "A Url é obrigatória"),
                    AssertionConcern.AssertTrue((video.DateEnd >= video.DateStart), "A data de fim deve ser maior que a data de início"),
                    AssertionConcern.AssertNotNull(video.TvAdditional, "Mesmo que não tenha tv adicional deve ser informado o valor 0")
                );
        }

        public static bool UpdateVideoScopeIsValid(this Video video, UpdateVideoCommand newVideo)
        {
            return AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotEmpty(newVideo.Url, "A Url é obrigatória"),
                    AssertionConcern.AssertTrue((newVideo.DateEnd >= newVideo.DateStart), "A data de fim deve ser maior que a data de início"),
                    AssertionConcern.AssertNotNull(newVideo.TvAdditional, "Mesmo que não tenha tv adicional deve ser informado o valor 0")
                );
        }
    }
}

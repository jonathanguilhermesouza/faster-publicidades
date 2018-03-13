using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public class TimeVideoSpecs
    {
        public static Expression<Func<TimeVideo, bool>> GetTimeVideo(string word)
        {

            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdTimeVideo.Equals(null);

            return x => (x.Time.Equals(word));
        }
    }
}

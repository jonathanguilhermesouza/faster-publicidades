using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public static class TypeVideoSpecs
    {
        public static Expression<Func<TypeVideo, bool>> GetTypeVideo(string word)
        {

            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdTypeVideo.Equals(null);

            return x => (x.Type.Contains(word));
        }
    }
}

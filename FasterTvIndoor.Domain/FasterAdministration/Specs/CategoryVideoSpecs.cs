using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public static class CategoryVideoSpecs
    {
        public static Expression<Func<CategoryVideo, bool>> GetCategoryVideo(string word)
        {

            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdCategoryVideo.Equals(null);

            return x => (x.Category.Contains(word));
        }
    }
}

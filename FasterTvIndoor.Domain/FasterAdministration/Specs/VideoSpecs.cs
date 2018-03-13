using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public static class VideoSpecs
    {
        public static Expression<Func<Video, bool>> GetVideo(string word, EStatusVideo status)
        {

            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdVideo.Equals(null) && x.Status == status;

            return x => (x.Company.CompanyName.Contains(word) || x.Company.FantasyName.Contains(word) || x.CategoryVideo.Category.Contains(word) || x.TypeVideo.Type.Contains(word));
        }

        public static Expression<Func<Video, bool>> GetVideoCompany(int id, EStatusVideo status)
        {
            return x => x.IdCompany == id && x.Status == status;
        }

    }
}

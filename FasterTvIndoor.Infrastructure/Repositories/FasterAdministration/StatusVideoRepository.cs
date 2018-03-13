using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class StatusVideoRepository : IStatusVideoRepository 
    {
        public List<StatusVideo> GetAll()
        {
            StatusVideo status;
            List<StatusVideo> listStatusVideo = new List<StatusVideo>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EStatusVideo)))
            {
                status = new StatusVideo();
                status.Id = i;
                status.Name = item.ToString();

                listStatusVideo.Add(status);

                i++;
            }

            return listStatusVideo;
        }
    }
}

using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.Account.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.Account
{
    public class StatusUserRepository : IStatusUserRepository
    {
        public List<StatusUser> GetAll()
        {
            StatusUser status;
            List<StatusUser> listStatus = new List<StatusUser>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EStatusUser)))
            {
                status = new StatusUser();
                status.Id = i;
                status.Name = item.ToString();

                listStatus.Add(status);

                i++;
            }

            return listStatus;
        }
    }
}

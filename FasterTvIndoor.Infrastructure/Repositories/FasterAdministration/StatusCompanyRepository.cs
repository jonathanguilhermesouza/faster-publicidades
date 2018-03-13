using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class StatusCompanyRepository : IStatusCompanyRepository
    {
        public List<StatusCompany> GetAll()
        {

            StatusCompany status;
            List<StatusCompany> listStatus = new List<StatusCompany>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EStatusCompany)))
            {
                status = new StatusCompany();
                status.Id = i;
                status.Name = item.ToString();

                listStatus.Add(status);

                i++;
            }

            return listStatus;
        }
    }
}

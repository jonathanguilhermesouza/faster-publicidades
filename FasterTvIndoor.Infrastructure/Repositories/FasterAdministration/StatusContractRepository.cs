using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class StatusContractRepository : IStatusContractRepository
    {
        public List<StatusContract> GetAll()
        {
            StatusContract statusContract;

            List<StatusContract> listStatusContract = new List<StatusContract>();
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(EStatusContract)))
            {
                statusContract = new StatusContract();
                statusContract.Id = i;
                statusContract.Name = item.ToString();

                listStatusContract.Add(statusContract);
                i++;
            }
            return listStatusContract;
        }
    }
}

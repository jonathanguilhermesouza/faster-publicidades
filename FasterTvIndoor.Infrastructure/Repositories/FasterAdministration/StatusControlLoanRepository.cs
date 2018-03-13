using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class StatusControlLoanRepository : IStatusControlLoanRepository
    {
        public List<StatusControlLoan> GetAll()
        {

            StatusControlLoan status;
            List<StatusControlLoan> listStatusControlLoan = new List<StatusControlLoan>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EStatusControlLoan)))
            {
                status = new StatusControlLoan();
                status.Id = i;
                status.Name = item.ToString();

                listStatusControlLoan.Add(status);

                i++;
            }

            return listStatusControlLoan;
        }
    }
}

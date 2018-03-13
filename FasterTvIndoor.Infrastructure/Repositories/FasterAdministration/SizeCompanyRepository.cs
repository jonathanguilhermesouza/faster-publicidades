using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class SizeCompanyRepository : ISizeCompanyRepository
    {
        public List<SizeCompany> GetAll()
        {
            SizeCompany sizeCompany;

            List<SizeCompany> listSizeCompany = new List<SizeCompany>();
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(ESizeCompany)))
            {
                sizeCompany = new SizeCompany();
                sizeCompany.Id = i;
                sizeCompany.Size = item.ToString();

                listSizeCompany.Add(sizeCompany);
                i++;
            }
            return listSizeCompany;
        }
    }
}

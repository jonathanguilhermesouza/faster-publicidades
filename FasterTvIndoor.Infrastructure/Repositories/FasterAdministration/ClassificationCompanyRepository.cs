using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class ClassificationCompanyRepository : IClassificationCompanyRepository
    {
        public List<ClassificationCompany> GetAll()
        {

            ClassificationCompany classification;
            List<ClassificationCompany> listClassification = new List<ClassificationCompany>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EClassificationCompany)))
            {
                classification = new ClassificationCompany();
                classification.Id = i;
                classification.Name = item.ToString();

                listClassification.Add(classification);

                i++;
            }

            return listClassification;
        }
    }
}

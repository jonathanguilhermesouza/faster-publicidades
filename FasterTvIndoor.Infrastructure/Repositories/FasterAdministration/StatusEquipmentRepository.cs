using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class StatusEquipmentRepository : IStatusEquipmentRepository
    {
        public List<StatusEquipment> GetAll()
        {

            StatusEquipment status;
            List<StatusEquipment> listStatusEquipment = new List<StatusEquipment>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EStatusEquipment)))
            {
                status = new StatusEquipment();
                status.Id = i;
                status.Name = item.ToString();

                listStatusEquipment.Add(status);

                i++;
            }

            return listStatusEquipment;
        }
    }
}

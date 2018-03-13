using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public static class HistoryEquipmentSpecs
    {        
        public static Expression<Func<HistoryEquipment, bool>> GetHistoryEquipment(int id)
        {
            return x => (x.IdEquipment == id);
        }

        public static Expression<Func<HistoryEquipment, bool>> GetHistoryCompany(int id)
        {
            return x => (x.IdCompany == id);
        }
    }
}

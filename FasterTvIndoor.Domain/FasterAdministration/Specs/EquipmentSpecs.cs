using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public static class EquipmentSpecs
    {
        public static Expression<Func<Equipment, bool>> GetEquipment(string word,EStatusEquipment status)
        {
            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdEquipment.Equals(null) && x.StatusEquipment == status;

            return x => (x.Patrimony.Contains(word) || x.Model.Contains(word) || x.SerialNumber.Contains(word) || x.TypeEquipment.Type.Contains(word)) && x.StatusEquipment == status;
        }
    }
}

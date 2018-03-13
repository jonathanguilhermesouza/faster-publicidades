using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Persistence.Mapping.FasterAdministration
{
    public class TypeEquipment
    {
        public TypeEquipment(){}

        public TypeEquipment(string type)
        {
            this.Type = type;
        }
        public int IdTypeEquipment { get; set; }
        public string Type { get; set; }
        public ICollection<Equipment> ListEquipment { get; set; }

        public void Create()
        {
            if (!this.CreateTypeEquipmentScopeIsValid())
                return;
        }

        public void Update(UpdateTypeEquipmentCommand command)
        {
            if (!this.UpdateTypeEquipmentScopeIsValid(command))
                return;

            this.Type = command.Type;
        }

        public void Delete(DeleteTypeEquipmentCommand command)
        {
            this.IdTypeEquipment = command.IdTypeEquipment;
        }
    }
}

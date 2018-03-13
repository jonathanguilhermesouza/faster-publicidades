using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.EquipmentCoomands
{
    public class DeleteEquipmentCommand
    {
        public DeleteEquipmentCommand(int idEquipment)
        {
            this.IdEquipment = idEquipment;
        }
        public int IdEquipment { get; private set; }     
    }
}

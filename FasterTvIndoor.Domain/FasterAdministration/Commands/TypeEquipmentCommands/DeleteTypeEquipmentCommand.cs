
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.TypeEquipmentCommands
{
    public class DeleteTypeEquipmentCommand
    {
        public DeleteTypeEquipmentCommand(int idTypeEquipment)
        {
            this.IdTypeEquipment = idTypeEquipment;
        }

        public int IdTypeEquipment { get; set; }
    }
}

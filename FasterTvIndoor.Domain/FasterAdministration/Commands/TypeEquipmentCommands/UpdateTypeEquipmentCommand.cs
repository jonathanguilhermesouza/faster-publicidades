
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.TypeEquipmentCommands
{
    public class UpdateTypeEquipmentCommand
    {
        public UpdateTypeEquipmentCommand(int idTypeEquipment, string type)
        {
            this.IdTypeEquipment = idTypeEquipment;
            this.Type = type;
        }
        public int IdTypeEquipment { get; set; }
        public string Type { get; set; }
    }
}


namespace FasterTvIndoor.Domain.FasterAdministration.Commands.TypeEquipmentCommands
{
    public class CreateTypeEquipmentCommand
    {
        public CreateTypeEquipmentCommand(string type)
        {
            this.Type = type;
        }
        public string Type { get; set; }
    }
}


namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PlanCommands
{
    public class CreatePlanCommand
    {
        public CreatePlanCommand() {}
        public CreatePlanCommand(decimal valueEquipmentMain, decimal valueEquipmentAdditional, decimal valueUpdate, string description, string title)
        {
            this.Description = description;
            this.Title = title;
            this.ValueEquipmentAdditional = valueEquipmentAdditional;
            this.ValueEquipmentMain = valueEquipmentMain;
            this.ValueUpdate = valueUpdate;
        }
        public string Description { get; private set; }
        public string Title { get; set; }
        public decimal ValueEquipmentMain { get; set; }
        public decimal ValueEquipmentAdditional { get; set; }
        public decimal ValueUpdate { get; set; }

    }
}


namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PlanCommands
{
    public class UpdatePlanCommand
    {
        public UpdatePlanCommand() { }
        public UpdatePlanCommand(int idPlan, decimal valueEquipmentMain, decimal valueEquipmentAdditional, decimal valueUpdate, string description, string title)
        {
            this.IdPlan = idPlan;
            this.Description = description;
            this.Title = title;
            this.ValueEquipmentAdditional = valueEquipmentAdditional;
            this.ValueEquipmentMain = valueEquipmentMain;
            this.ValueUpdate = valueUpdate;
        }
        public int IdPlan { get; private set; }
        public string Description { get; private set; }
        public string Title { get; set; }
        public decimal ValueEquipmentMain { get; set; }
        public decimal ValueEquipmentAdditional { get; set; }
        public decimal ValueUpdate { get; set; }
    }
}

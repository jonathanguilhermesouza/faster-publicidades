using FasterTvIndoor.Domain.FasterAdministration.Commands.PlanCommands;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class Plan
    {
        public Plan() { }
        public Plan(decimal valueEquipmentMain, decimal valueEquipmentAdditional, decimal valueUpdate, string description, string title)
        {
            this.Description = description;
            this.Title = title;
            this.ValueEquipmentAdditional = valueEquipmentAdditional;
            this.ValueEquipmentMain = valueEquipmentMain;
            this.ValueUpdate = valueUpdate;
        }
        public int IdPlan { get; private set; }
        public decimal ValueEquipmentMain { get; set; }
        public decimal ValueEquipmentAdditional { get; set; }
        public decimal ValueUpdate { get; set; }
        public string Description { get; private set; }
        public string Title { get; set; }
        public ICollection<Video> ListVideo { get; private set; }

        public void Create()
        {
            if (!this.CreatePlanScopeIsValid())
                return;
        }

        public void Update(UpdatePlanCommand command)
        {
            if (!this.UpdatePlanScopeIsValid(command))
                return;

            this.Description = command.Description;
            this.Title = command.Title;
            this.ValueEquipmentAdditional = command.ValueEquipmentAdditional;
            this.ValueEquipmentMain = command.ValueEquipmentMain;
            this.ValueUpdate = command.ValueUpdate;
        }
    }
}



/*
Titulo
Tempo de publicidade
Valor de atualização
Valor equipamento principal
Valor equipamento adicional
Descrição





     public Plan() {}
        public Plan(decimal value,string description, int amountTv, string title)
        {
            //this.Value = value;
            this.Description = description;
            //this.AmountTv = amountTv;
            this.Title = title;
        }
public int IdPlan { get; private set; }
public decimal ValueEquipmentMain { get; set; }
public decimal ValueEquipmentAdditional { get; set; }
public decimal ValueUpdate { get; set; }
//public decimal Value { get; private set; }
public string Description { get; private set; }
public string Title { get; set; }
//public int AmountTv { get; set; }
//public ICollection<Contract> ListContract { get; private set; }
public ICollection<Video> ListVideo { get; private set; }

public void Create()
{
    if (!this.CreatePlanScopeIsValid())
        return;
}

public void Update(UpdatePlanCommand command)
{
    if (!this.UpdatePlanScopeIsValid(command))
        return;

    //this.Value = command.Value;
    this.Description = command.Description;
    this.Title = command.Title;
    //this.AmountTv = command.AmountTv;
}

*/

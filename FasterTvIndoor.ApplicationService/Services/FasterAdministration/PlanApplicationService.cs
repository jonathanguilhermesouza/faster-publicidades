using FasterTvIndoor.Domain.FasterAdministration.Commands.PlanCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class PlanApplicationService: ApplicationService,IPlanApplicationService
    {
        private IPlanRepository _repository;
        public PlanApplicationService(IPlanRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<Plan> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Plan> GetByRange(int skip, int take, string word)
        {
            return _repository.GetByRange(skip, take, word);
        }

        public Plan GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Plan Create(CreatePlanCommand command)
        {
            var plan = new Plan(command.ValueEquipmentMain, command.ValueEquipmentAdditional, command.ValueUpdate, command.Description, command.Title);
            plan.Create();
            _repository.Create(plan);
            
            if (Commit())
                return plan;

            return null;
        }

        public Plan Update(UpdatePlanCommand command)
        {
            var plan = _repository.GetById(command.IdPlan);
            plan.Update(command);
            _repository.Update(plan);
            
            if (Commit())
                return plan;

            return null;
        }

        public Plan Delete(/*DeletePlanCommand command*/)
        {
            return null;
        }

        public int GetCount(string word)
        {
            return _repository.GetCount(word);
        }
    }
}

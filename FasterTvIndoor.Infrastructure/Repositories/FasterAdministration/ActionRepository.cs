using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class ActionRepository : IActionRepository
    {

        public List<_Action> GetAll()
        {
            _Action action;
            List<_Action> listAction = new List<_Action>();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(EAction)))
            {
                action = new _Action();


                action.Id = i;
                action.Name = item.ToString();

                listAction.Add(action);

                i++;

            }

            return listAction;
        }
    }

}
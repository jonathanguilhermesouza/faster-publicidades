using FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Commands.PlanCommands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class PlanController : BaseController
    {
        private readonly IPlanApplicationService _service;

        public PlanController(IPlanApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/plan/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var plan = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, plan);
        }

        [HttpGet]
        [Route("api/plan/range/{skip:int:min(0)}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, string word, int take = 12)
        {
            var plan = _service.GetByRange(skip, take, word);
            return CreateResponse(HttpStatusCode.OK, plan);
        }

        [HttpGet]
        [Route("api/plan")]
        public Task<HttpResponseMessage> GetAll()
        {
            var plan = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, plan);
        }

        [HttpGet]
        [Route("api/plan/count/{word}")]
        public Task<HttpResponseMessage> GetCount(string word)
        {
            var countPlan = _service.GetCount(word);
            return CreateResponse(HttpStatusCode.OK, countPlan);
        }

        [HttpPost]
        [Route("api/plan/")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            decimal value = Convert.ToDecimal(body.value);

            var command = new CreatePlanCommand(
                valueEquipmentMain: (decimal)body.valueEquipmentMain,
                valueEquipmentAdditional: (decimal)body.valueEquipmentAdditional,
                valueUpdate: (decimal)body.valueUpdate,
                description: (string)body.description,
                title: (string)body.title
            );

            var plan = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, plan);
        }


        [HttpDelete]
        [Route("api/plan/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            
            return CreateResponse(HttpStatusCode.OK, null);
        }

        [HttpPut]
        [Route("api/plan/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdatePlanCommand(
                idPlan: id,
                valueEquipmentMain: (decimal)body.valueEquipmentMain,
                valueEquipmentAdditional: (decimal)body.valueEquipmentAdditional,
                valueUpdate: (decimal)body.valueUpdate,
                description: (string)body.description,
                title: (string)body.title
            );

            var plan = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, plan);
        }
    }
}

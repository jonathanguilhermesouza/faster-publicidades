using FasterTvIndoor.Domain.FasterAdministration.Commands.HistoryEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class HistoryEquipmentController : BaseController
    {

        private readonly IHistoryEquipmentApplicationService _service;

        public HistoryEquipmentController(IHistoryEquipmentApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/historyequipment/")]
        public Task<HttpResponseMessage> GetAll()
        {
            var history = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, history);
        }

        [HttpGet]
        [Route("api/historyequipment/range/{skip:int:min(0)}/{take:int:min(0)}/{id}")]
        public Task<HttpResponseMessage> GetByRangeEquipment(int skip, int id, int take = 12)
        {
            var history = _service.GetByRangeEquipment(skip, take, id);
            return CreateResponse(HttpStatusCode.OK, history);
        }

        [HttpGet]
        [Route("api/historyequipment/company/range/{skip:int:min(0)}/{take:int:min(0)}/{id}")]
        public Task<HttpResponseMessage> GetByRangeCompany(int skip, int id, int take = 12)
        {
            var history = _service.GetByRangeCompany(skip, take, id);
            return CreateResponse(HttpStatusCode.OK, history);
        }

        [HttpGet]
        [Route("api/historyequipment/count/{id}")]
        public Task<HttpResponseMessage> GetCount(int id)
        {
            var countHistory = _service.GetCount(id);
            return CreateResponse(HttpStatusCode.OK, countHistory);
        }

        [HttpGet]
        [Route("api/historyequipment/company/count/{id}")]
        public Task<HttpResponseMessage> GetCountByCompany(int id)
        {
            var countHistory = _service.GetCountByCompany(id);
            return CreateResponse(HttpStatusCode.OK, countHistory);
        }

        [HttpGet]
        [Route("api/historyequipment/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var history = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, history);
        }

        [HttpPost]
        [Route("api/historyequipment/")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateHistoryEquipmentCommand(
                 idVideo: (int)body.idVideo,
                 idEquipment: (int)body.idEquipment,
                 value: (decimal)body.value,
                 idCompany: (int)body.idCompany,
                 plan: (string)body.plan
            );

            var history = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, history);
        }

        [HttpPut]
        [Route("api/historyequipment/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateHistoryEquipmentCommand(
                idHistoryEquipment: id,
                idVideo: (int)body.idVideo,
                idEquipment: (int)body.idEquipment,
                value: (decimal)body.value,
                idCompany: (int)body.idCompany,
                plan:(string)body.plan
           );

            var history = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, history);

        }

    }
}

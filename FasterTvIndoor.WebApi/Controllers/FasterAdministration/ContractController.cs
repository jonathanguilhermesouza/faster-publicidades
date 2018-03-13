using FasterTvIndoor.Domain.FasterAdministration.Commands.ContractCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    //[Authorize(Roles = "Suporte,Master")]
    public class ContractController : BaseController
    {
        private readonly IContractApplicationService _service;

        public ContractController(IContractApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/contract")]
        public Task<HttpResponseMessage> GetAll()
        {
            var contract = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, contract);
        
        }
        [HttpGet]
        [Route("api/contract/range/{skip:int:min(0)}/{status}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, string word, EStatusContract status, int take = 12)
        {
            var contract = _service.GetByRange(skip, take, word, status);
            return CreateResponse(HttpStatusCode.OK, contract);
        }

        [HttpGet]
        [Route("api/contract/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var contract = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, contract);
        }

        [HttpGet]
        [Route("api/contract/count/{status}/{word}")]
        public Task<HttpResponseMessage> GetCount(string word, EStatusContract status)
        {
            var countContract = _service.GetCount(word, status);
            return CreateResponse(HttpStatusCode.OK, countContract);
        }

        [HttpPost]
        [Route("api/contract")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateContractCommand(
                idCompany: (int)body.idCompany,                
                idDayOfMonth: (int)body.idDayOfMonth,
                dateStart: (DateTime)body.dateStart,
                dateEnd: (DateTime)body.dateEnd,
                note: (string)body.note
            );

            var contract = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, contract);
        }

        [HttpPut]
        [Route("api/contract/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateContractCommand(
                idContract: id,
                idCompany: (int)body.idCompany,
                idDayOfMonth: (int)body.idDayOfMonth,
                dateStart: (DateTime)body.dateStart,
                dateEnd: (DateTime)body.dateEnd,
                statusContract: (EStatusContract)body.statusContract,
                note: (string)body.note
            );

            var contract = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, contract);
        }

        [HttpPut]
        [Route("api/contract/c/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Cancel([FromBody]dynamic body)
        {
            var command = new CancelContractCommand(
                idContract: (int)body.idContract,
                idCompany: (int)body.idCompany,
                //idPlan: (int)body.idPlan,
                note: (string)body.note
            );

            var contract = _service.Cancel(command);
            return CreateResponse(HttpStatusCode.OK, contract);
        }


    }
}
using FasterTvIndoor.Domain.FasterAdministration.Commands.ControlLoanCommands;
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
    public class ControlLoanController : BaseController
    {
        private readonly IControlLoanApplicationService _service;

        public ControlLoanController(IControlLoanApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/loan")]
        public Task<HttpResponseMessage> GetAll()
        {
            var loan = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, loan);
        }

        [HttpGet]
        [Route("api/loan-equipment/{status}/{word}")]
        public Task<HttpResponseMessage> GetAllControlLoanEquipment(EStatusControlLoan status, int word)
        {
            var loan = _service.GetAllControlLoanEquipment(word, status);
            return CreateResponse(HttpStatusCode.OK, loan);
        }

        [HttpGet]
        [Route("api/loan-equipment/{status}/{video}/{word}")]
        public Task<HttpResponseMessage> GetAllControlLoanEquipment(EStatusControlLoan status, int video, int word)
        {
            var loan = _service.GetAllControlLoanEquipmentByVideo(video, word, status);
            return CreateResponse(HttpStatusCode.OK, loan);
        }

        [HttpGet]
        [Route("api/loan/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var loan = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, loan);
        }

        [HttpGet]
        [Route("api/loan/range/{skip:int:min(0)}/{status}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, string word, EStatusControlLoan status, int take = 12)
        {
            var loan = _service.GetByRange(skip, take, word, status);
            return CreateResponse(HttpStatusCode.OK, loan);
        }

        [HttpPost]
        [Route("api/loan")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateControlLoanCommand(
               dateLocation: (DateTime)body.dateLocation,
               dateEndLocation: (DateTime)body.dateEndLocation,
               note: (string)body.note,
               idCompany: (int)body.idCompany,
               idEquipment: (int)body.idEquipment
            );

            var loan = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, loan);
        }

        [HttpPut]
        [Route("api/loan/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body, int id)
        {
            var command = new UpdateControlLoanCommand(
                idControlLoan: id,
                dateLocation: (DateTime)body.dateLocation,
                dateEndLocation: (DateTime)body.dateEndLocation,
                note: (string)body.note,
                statusControlLoan: (EStatusControlLoan)body.statusControlLoan,
                idCompany: (int)body.idCompany,
                idEquipment: (int)body.idEquipment
            );

            var loan = _service.Update(command);
            return CreateResponse(HttpStatusCode.Created, loan);
        }

        [HttpDelete]
        [Route("api/loan/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var command = new DeleteControlLoanCommand(
                idControlLoan: id
            );
            var loan = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, loan);
        }

        [HttpGet]
        [Route("api/loan/count/{status}/{word}")]
        public Task<HttpResponseMessage> GetCount(string word, EStatusControlLoan status)
        {
            var countControlLoan = _service.GetCount(word, status);
            return CreateResponse(HttpStatusCode.OK, countControlLoan);
        }

    }
}

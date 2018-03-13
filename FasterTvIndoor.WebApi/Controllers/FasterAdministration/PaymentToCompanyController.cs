using FasterTvIndoor.Domain.FasterAdministration.Commands.PaymentToCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class PaymentToCompanyController : BaseController
   { 

        private readonly IPaymentToCompanyApplicationService _service;

        public PaymentToCompanyController(IPaymentToCompanyApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/payment")]
        public Task<HttpResponseMessage> GetAll()
        {
            var payment = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, payment);
        }

        [HttpGet]
        [Route("api/payment/range/{skip:int:min(0)}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, string word, int take = 12)
        {
            var payment = _service.GetByRange(skip, take, word);
            return CreateResponse(HttpStatusCode.OK, payment);
        }

        [HttpGet]
        [Route("api/payment/range/company/{skip:int:min(0)}/{id}")]
        public Task<HttpResponseMessage> GetByRangeCompany(int skip, int id, int take = 12)
        {
            var payment = _service.GetByRangeCompany(skip, take, id);
            return CreateResponse(HttpStatusCode.OK, payment);
        }

        [HttpGet]
        [Route("api/payment/count/company/{id}")]
        public Task<HttpResponseMessage> GetCountCompany(int id)
        {
            var countPayment = _service.GetCountCompany(id);
            return CreateResponse(HttpStatusCode.OK, countPayment);
        }

        [HttpGet]
        [Route("api/payment/count/{word}")]
        public Task<HttpResponseMessage> GetCount(string word)
        {
            var countPayment = _service.GetCount(word);
            return CreateResponse(HttpStatusCode.OK, countPayment);
        }

        [HttpGet]
        [Route("api/payment/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var payment = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, payment);
        }

        [HttpGet]
        [Route("api/payment/company/{id}")]
        public Task<HttpResponseMessage> GetByIdCompany(int id)
        {
            var payment = _service.GetByIdCompany(id);
            return CreateResponse(HttpStatusCode.OK, payment);
        }

        [HttpPost]
        [Route("api/payment")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreatePaymentToCompanyCommand(
                idCompany: (int)body.idCompany,
                value: (decimal)body.value,
                datePayment: (DateTime)body.datePayment,
                description: (string)body.description
            );

            var payment = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, payment);
        }

        [HttpPut]
        [Route("api/payment/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdatePaymentToCompanyCommand(
                idPaymentToCompany: id,
                idCompany: (int)body.idCompany,
                value: (decimal)body.value,
                datePayment: (DateTime)body.datePayment,
                description: (string)body.description
           );

            var payment = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, payment);

        }

        [HttpDelete]
        [Route("api/payment/{id:int:min(0)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {

            var command = new DeletePaymentToCompanyCommand(
                idPaymentToCompany: id
            );

            var payment = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, payment);
        }

    }
}

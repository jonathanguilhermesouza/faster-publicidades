using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class PaymentToCompanyComplementController : BaseController
    {

        private readonly IPaymentToCompanyComplementApplicationService _service;

        public PaymentToCompanyComplementController(IPaymentToCompanyComplementApplicationService service)
        {
            this._service = service;
        }
        [HttpGet]
        [Route("api/paymentcomplement/range/company/{skip:int:min(0)}/{id}")]
        public Task<HttpResponseMessage> GetByRangeCompany(int skip, int id, int take = 100)
        {
            var payment = _service.GetByRangeCompany(skip, take, id);
            return CreateResponse(HttpStatusCode.OK, payment);
        }

    }
}

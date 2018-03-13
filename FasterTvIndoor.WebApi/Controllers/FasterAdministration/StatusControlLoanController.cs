using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    [Authorize(Roles = "Suporte,Master")]
    public class StatusControlLoanController : BaseController
    {

        private readonly IStatusControlLoanApplicationService _service;
        public StatusControlLoanController(IStatusControlLoanApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/status-loan")]
        public Task<HttpResponseMessage> GetAll()
        {
            var status = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, status);
        }
    }
}

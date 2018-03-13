using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    [Authorize(Roles = "Suporte,Master")]
    public class StatusController : BaseController
    {
        private readonly IStatusCompanyApplicationService _service;

        public StatusController(IStatusCompanyApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/status")]
        public Task<HttpResponseMessage> GetAll()
        {
            var status = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, status);
        }
    }
}

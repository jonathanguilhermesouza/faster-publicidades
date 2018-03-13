using FasterTvIndoor.Domain.Account.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.Account
{
    public class StatusUserController : BaseController
    {
        private readonly IStatusUserApplicationService _service;

        public StatusUserController(IStatusUserApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/status-user")]
        public Task<HttpResponseMessage> GetAll()
        {
            var statusUser = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, statusUser);
        }
    }
}

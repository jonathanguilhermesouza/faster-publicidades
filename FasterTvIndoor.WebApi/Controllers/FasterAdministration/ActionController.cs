using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class ActionController : BaseController
    {
        private readonly IActionApplicationService _service;

        public ActionController(IActionApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/action")]
        public Task<HttpResponseMessage> GetAll()
        {
            var actions = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, actions);
        }
    }
}

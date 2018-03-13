using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    [Authorize(Roles = "Suporte,Master")]
    public class ClassificationController : BaseController
    {
        private readonly IClassificationCompanyApplicationService _service;

        public ClassificationController(IClassificationCompanyApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/classification")]
        public Task<HttpResponseMessage> GetAll()
        {
            var classification = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, classification);
        }
    }
}

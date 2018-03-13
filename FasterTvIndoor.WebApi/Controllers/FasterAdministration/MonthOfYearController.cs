using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class MonthOfYearController : BaseController
    {
        private readonly IMonthOfYearApplicationService _service;

        public MonthOfYearController(IMonthOfYearApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/monthofyear")]
        public Task<HttpResponseMessage> GetAll()
        {
            var status = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, status);
        }
    }
}

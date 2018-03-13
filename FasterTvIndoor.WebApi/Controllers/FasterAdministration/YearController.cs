using FasterTvIndoor.Domain.FasterAdministration.Commands.YearCommands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class YearController : BaseController
    {
        private readonly IYearApplicationService _service;
        public YearController(IYearApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/year")]
        public Task<HttpResponseMessage> GetAll()
        {
            var year = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, year);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/year")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateYearCommand(
                number: (int)body.number
            );

            var sector = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, sector);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/year/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateYearCommand(
                idYear: id,
                number: (int)body.number
            );

            var year = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, year);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/year/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var year = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, year);
        }
    }
}

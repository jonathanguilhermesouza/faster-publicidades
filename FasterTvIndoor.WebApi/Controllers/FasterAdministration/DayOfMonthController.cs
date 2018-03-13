using FasterTvIndoor.Domain.FasterAdministration.Commands.DayOfMonth;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class DayOfMonthController : BaseController
    {

        private readonly IDayOfMonthApplicationService _service;

        public DayOfMonthController(IDayOfMonthApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/dayofmonth")]
        public Task<HttpResponseMessage> GetAll()
        {
            var dayofmonth = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, dayofmonth);
        }
        
        [HttpGet]
        [Route("api/dayofmonth/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var dayofmonth = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, dayofmonth);
        }

        [HttpPost]
        [Route("api/dayofmonth")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateDayOfMonthCommand(
                day: (int)body.day
            );

            var dayofmonth = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, dayofmonth);
        }

        [HttpPut]
        [Route("api/dayofmonth/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateDayOfMonthCommand(
                idDayOfMonth: id,
                day: (int)body.day
           );

            var dayofmonth = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, dayofmonth);

        }

    }
}

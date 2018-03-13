using FasterTvIndoor.Domain.FasterAdministration.Commands.TimeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class TimeVideoController : BaseController
    {
        
        private readonly ITimeVideoApplicationService _service;

        public TimeVideoController(ITimeVideoApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/time-video")]
        public Task<HttpResponseMessage> GetAll()
        {
            var time = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, time);
        }

        [HttpGet]
        [Route("api/time-video/range/{skip:int:min(0)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take = 12)
        {
            var time = _service.GetByRange(skip, take);
            return CreateResponse(HttpStatusCode.OK, time);
        }

        [HttpGet]
        [Route("api/time-video/count")]
        public Task<HttpResponseMessage> GetCount()
        {
            var countTimeVideo = _service.GetCount();
            return CreateResponse(HttpStatusCode.OK, countTimeVideo);
        }

        [HttpGet]
        [Route("api/time-video/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var time = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, time);
        }

        [HttpPost]
        [Route("api/time-video")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {

            var command = new CreateTimeVideoCommand(
                time: (body.time != null) ? (int)body.time : 0
            );

            var time = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, time);
        }

        [HttpDelete]
        [Route("api/time-video/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            /*var command = new DeleteTimeVideoCommand(
                idTimeVideo: id
            );

            var equipment = _service.Delete(command);*/
            return CreateResponse(HttpStatusCode.OK, null);
        }

        [HttpPut]
        [Route("api/time-video/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateTimeVideoCommand(
                idTimeVideo: id,
                time: (int)body.time
           );

            var time = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, time);

        }

    }
}

using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class VideoEquipmentController : BaseController
    {

        private readonly IVideoEquipmentApplicationService _service;

        public VideoEquipmentController(IVideoEquipmentApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/equipment-video")]
        public Task<HttpResponseMessage> GetAll()
        {
            var video = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, video);
        }

        [HttpGet]
        [Route("api/equipment-video/range/{word}/{skip:int:min(0)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, string word, int take = 12)
        {
            var video = _service.GetByRange(skip, take, word);
            return CreateResponse(HttpStatusCode.OK, video);
        }

        [HttpGet]
        [Route("api/equipment-video/company/range/{skip:int:min(0)}/{id}")]
        public Task<HttpResponseMessage> GetByRangeCompany(int skip, int id, int take = 12)
        {
            var video = _service.GetByRangeCompany(skip, take, id);
            return CreateResponse(HttpStatusCode.OK, video);
        }

        [HttpGet]
        [Route("api/equipment-video/count/{word}")]
        public Task<HttpResponseMessage> GetCount(string word)
        {
            var countVideo = _service.GetCount(word);
            return CreateResponse(HttpStatusCode.OK, countVideo);
        }

        [HttpGet]
        [Route("api/equipment-video/company/count/{id}")]
        public Task<HttpResponseMessage> GetCountByCompany(int id)
        {
            var countVideo = _service.GetVideoCountByCompany(id);
            return CreateResponse(HttpStatusCode.OK, countVideo);
        }

        [HttpGet]
        [Route("api/equipment-video/id/{equipment}/{video}")]
        public Task<HttpResponseMessage> GetIdVideoEquipment(int equipment, int video)
        {
            var videoEquipment = _service.GetIdVideoEquipment(equipment, video);
            return CreateResponse(HttpStatusCode.OK, videoEquipment);
        }

        [HttpDelete]
        [Route("api/equipment-video/{equipment}/{video}/{controlLoan}")]
        public Task<HttpResponseMessage> Delete(int equipment,int video, int controlLoan)
        {
            var videoEquipment = _service.Delete(equipment, video, controlLoan);
            return CreateResponse(HttpStatusCode.OK, videoEquipment);
        }

        [HttpGet]
        [Route("api/equipment-video/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var video = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, video);
        }

        [HttpGet]
        [Route("api/equipment-video/equipment/{id}")]
        public Task<HttpResponseMessage> GetByIdEquipment(int id)
        {
            var video = _service.GetByIdEquipment(id);
            return CreateResponse(HttpStatusCode.Created, video);
        }

        [HttpPost]
        [Route("api/equipment-video")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateVideoEquipmentCommand(
                idEquipment: (int)body.idEquipment,
                idVideo: (int)body.idVideo,
                idControlLoan: (int)body.idControlLoan
            );

            //var command = new CreateVideoEquipmentCommand(
            //         listVideoEquipment: body.listVideoEquipment.ToObject<List<VideoEquipment>>()
            //);

            var video = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, video);
        }

        [HttpPut]
        [Route("api/equipment-video/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateVideoEquipmentCommand(
                idVideoEquipment: id,
                idVideo: (int)body.idVideo,
                idEquipment: (int)body.idEquipment,
                idControlLoan: (int)body.idControlLoan
           );

            var video = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, video);

        }
    }
}

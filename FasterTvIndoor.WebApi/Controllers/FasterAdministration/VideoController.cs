using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class VideoController : BaseController
    {

        private readonly IVideoApplicationService _service;

        public VideoController(IVideoApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/video")]
        public Task<HttpResponseMessage> GetAll()
        {
            var video = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, video);
        }

        [HttpGet]
        [Route("api/video/range/{skip:int:min(0)}/{status}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, string word, EStatusVideo status, int take = 12)
        {
            var video = _service.GetByRange(skip, take, word, status);
            return CreateResponse(HttpStatusCode.OK, video);
        }

        [HttpGet]
        [Route("api/video/range/company/{skip:int:min(0)}/{status}/{id}")]
        public Task<HttpResponseMessage> GetByRangeCompany(int skip, int id, EStatusVideo status, int take = 12)
        {
            var video = _service.GetByRangeCompany(skip, take, id, status);
            return CreateResponse(HttpStatusCode.OK, video);
        }

        [HttpGet]
        [Route("api/video/count/company/{status}/{id}")]
        public Task<HttpResponseMessage> GetCount(int id, EStatusVideo status)
        {
            var countVideo = _service.GetCountCompany(id, status);
            return CreateResponse(HttpStatusCode.OK, countVideo);
        }

        [HttpGet]
        [Route("api/video/count/{status}/{word}")]
        public Task<HttpResponseMessage> GetCount(string word, EStatusVideo status)
        {
            var countVideo = _service.GetCount(word, status);
            return CreateResponse(HttpStatusCode.OK, countVideo);
        }

        [HttpGet]
        [Route("api/video/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var video = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, video);
        }

        [HttpPost]
        [Route("api/video")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateVideoCommand(
               url: (string)body.url,
               tvAdditional: (int)body.tvAdditional,
               idTimeVideo: (int)body.idTimeVideo,
               idTypeVideo: (int)body.idTypeVideo,
               idCompany: (int)body.idCompany,
               idCategoryVideo: (int)body.idCategoryVideo,
               idPlan: (int)body.idPlan,
               dateEnd: (DateTime)body.dateEnd,
               dateStart: (DateTime)body.dateStart,
               listVideoEquipment: body.listVideoEquipment.ToObject<List<VideoEquipment>>()
            );

            var video = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, video);
        }

        [HttpPut]
        [Route("api/video/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateVideoCommand(
                idVideo: id,
                url: (string)body.url,
                status: (EStatusVideo)body.status,
                tvAdditional: (int)body.tvAdditional,
                idTimeVideo: (int)body.idTimeVideo,
                idTypeVideo: (int)body.idTypeVideo,
                idCompany: (int)body.idCompany,
                idCategoryVideo: (int)body.idCategoryVideo,
                idPlan: (int)body.idPlan,
                dateEnd: (DateTime)body.dateEnd, 
                dateStart: (DateTime)body.dateStart,
                listVideoEquipment: body.listVideoEquipment.ToObject<List<VideoEquipment>>()
           );

            var video = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, video);

        }

        [HttpDelete]
        [Route("api/video/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var command = new DeleteVideoCommand(
                idVideo: id
            );

            var video = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, video);
        }

    }
}

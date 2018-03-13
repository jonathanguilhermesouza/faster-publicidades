using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class TypeVideoController : BaseController
    {
        
        private readonly ITypeVideoApplicationService _service;

        public TypeVideoController(ITypeVideoApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/type-video")]
        public Task<HttpResponseMessage> GetAll()
        {
            var type = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, type);
        }

        [HttpGet]
        [Route("api/type-video/range/{skip:int:min(0)}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip,string word, int take = 12)
        {
            var type = _service.GetByRange(skip, take, word);
            return CreateResponse(HttpStatusCode.OK, type);
        }

        [HttpGet]
        [Route("api/type-video/count/{word}")]
        public Task<HttpResponseMessage> GetCount(string word)
        {
            var countTypeVideo = _service.GetCount(word);
            return CreateResponse(HttpStatusCode.OK, countTypeVideo);
        }

        [HttpGet]
        [Route("api/type-video/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var type = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, type);
        }

        [HttpPost]
        [Route("api/type-video")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateTypeVideoCommand(
                type: (string)body.type
            );

            var type = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, type);
        }

        [HttpPut]
        [Route("api/type-video/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateTypeVideoCommand(
                idTypeVideo: id,
                type: (string)body.type
           );

            var type = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, type);

        }
    }
}

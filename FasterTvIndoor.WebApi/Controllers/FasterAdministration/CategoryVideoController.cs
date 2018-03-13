using FasterTvIndoor.Domain.FasterAdministration.Commands.CategoryVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    //[Authorize(Roles = "Suporte,Master")]
    public class CategoryVideoController : BaseController
    {

        private readonly ICategoryVideoApplicationService _service;

        public CategoryVideoController(ICategoryVideoApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/category-video")]
        public Task<HttpResponseMessage> GetAll()
        {
            var category = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, category);
        }

        [HttpGet]
        [Route("api/category-video/range/{skip:int:min(0)}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, string word, int take = 12)
        {
            var category = _service.GetByRange(skip, take, word);
            return CreateResponse(HttpStatusCode.OK, category);
        }

        [HttpGet]
        [Route("api/category-video/count/{word}")]
        public Task<HttpResponseMessage> GetCount(string word)
        {
            var countCategory = _service.GetCount(word);
            return CreateResponse(HttpStatusCode.OK, countCategory);
        }

        [HttpGet]
        [Route("api/category-video/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var category = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, category);
        }

        [HttpPost]
        [Route("api/category-video")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateCategoryVideoCommand(
                category: (string)body.category
            );

            var category = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, category);
        }

        [HttpPut]
        [Route("api/category-video/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id,[FromBody]dynamic body)
        {
            var command = new UpdateCategoryVideoCommand(
                idCategoryVideo: id,
                category: (string)body.category
           );

            var category = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, category);

        }

    }
}

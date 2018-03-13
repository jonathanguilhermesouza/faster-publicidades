using FasterTvIndoor.Domain.FasterAdministration.Commands.ProfileUserCommands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    [Authorize(Roles = "Suporte,Master,Cliente")]
    public class ProfileUserController : BaseController
    {
        private readonly IProfileUserApplicationService _service;

        public ProfileUserController(IProfileUserApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/profile")]
        public Task<HttpResponseMessage> GetAll()
        {
            var profile = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, profile);
        }
        [HttpGet]
        [Route("api/profile/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var profile = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, profile);
        }

        [HttpGet]
        [Route("api/profile/range/{skip:int:min(0)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take = 12)
        {
            var profile = _service.GetByRange(skip, take);
            return CreateResponse(HttpStatusCode.OK, profile);
        }

        [HttpPost]
        [Route("api/profile")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateProfileUserCommand(
                profile: (string)body.profile
            );

            var profile = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, profile);
        }

        [HttpPut]
        [Route("api/profile/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateProfileUserCompanyCommand(
                idProfileUser: id,
                profile: (string)body.profile
            );

            var profile = _service.Update(command);
            return CreateResponse(HttpStatusCode.Created, profile);
        }

        [HttpGet]
        [Route("api/profile/count")]
        public Task<HttpResponseMessage> GetCount()
        {
            var countProfile = _service.GetCount();
            return CreateResponse(HttpStatusCode.OK, countProfile);
        }

        [HttpDelete]
        [Route("api/profile/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var command = new DeleteProfileUserCommand(
                id: id
            );
            var profiles = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, profiles);
        }

    }
}
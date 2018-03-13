using FasterTvIndoor.Domain.Account.Commands.UserCommands;
using FasterTvIndoor.Domain.Account.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.ControlUser.Account
{
    public class UserController : BaseController
    {
        private readonly IUserApplicationService _service;

        public UserController(IUserApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/user")]
        //[Authorize(Roles="admin")]
        public Task<HttpResponseMessage> GetAll()
        {
            var users = _service.List();
            return CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [Route("api/user/email/{email}")]
        //[Authorize(Roles="admin")]
        public Task<HttpResponseMessage> GetByEmail(string email)
        {
            var user = _service.GetByEmail(email);
            return CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/user")]
        //[Authorize(Roles = "Administrador,Master,Suporte")]
        public Task<HttpResponseMessage> Post([FromBody] dynamic body)
        {
            var command = new RegisterUserCommand(
                    email: (string)body.email,
                    password: (string)body.password,
                    name: (string)body.name,
                    lastName: (string)body.lastName,
                    nickName: (string)body.nickName
                );

            var user = _service.Register(command);

            return CreateResponse(HttpStatusCode.Created, user);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/user/{id:int:min(1)}")]
        [Authorize(Roles = "Administrador,Master,Suporte")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateUserCommand(
                    idUser: id,
                    email: (string)body.email,
                    name: (string)body.name,
                    lastName: (string)body.lastName,
                    password: (string)body.password,
                    idProfileUser: (int)body.idProfileUser
            );

            var user = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, user);
        }
    }
}

using FasterTvIndoor.Domain.Client.Commands.PhoneUserCommands;
using FasterTvIndoor.Domain.Client.Services;
using FasterTvIndoor.WebApi.Controllers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RedeFaster.WebApi.Controllers.Client
{
    public class PhoneUserController : BaseController
    {
        private readonly IPhoneUserApplicationService _service;

        public PhoneUserController(IPhoneUserApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/phone-user/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var phone = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, phone);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/phone-user/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdatePhoneUserCommand(
                idPhoneUser: id,
                number: (string)body.number
            );

            var phone = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, phone);
        }

        [HttpDelete]
        [Route("api/phone-user/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {

            var command = new DeletePhoneUserCommand(
                idPhoneUser: id
            );

            var phone = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, phone);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/phone-user/")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreatePhoneUserCommand(
                number: (string)body.number,
                idUser: (int)body.idUser
            );

            var phone = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, phone);
        }
    }
}

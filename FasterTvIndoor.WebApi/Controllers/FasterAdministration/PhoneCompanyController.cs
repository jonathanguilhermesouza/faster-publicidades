using FasterTvIndoor.Domain.FasterAdministration.Commands.PhoneCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    [Authorize(Roles = "Administrador,Suporte,Master")]
    public class PhoneCompanyController : BaseController
    {
        private readonly IPhoneCompanyApplicationService _service;

        public PhoneCompanyController(IPhoneCompanyApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/company-phone/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var phone = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, phone);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/company-phone/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdatePhoneCompanyCommand(
                idPhoneCompany: id,
                number : (string)body.number
            );

            var phone = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, phone);
        }

        [HttpDelete]
        [Route("api/company-phone/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {

            var command = new DeletePhoneCompanyCommand(
                idPhoneCompany: id
            );

            var phone = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, phone);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/company-phone/")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreatePhoneCompanyCommand(
                number:(string)body.number,
                idCompany:(int)body.idCompany
            );

            var phone = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, phone);
        }

    }
}

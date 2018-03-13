using FasterTvIndoor.Domain.FasterAdministration.Commands.AddressCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    [Authorize(Roles = "Administrador,Suporte,Master")]
    public class AddressCompanyController : BaseController
    {
        private readonly IAddressCompanyApplicationService _service;

        public AddressCompanyController(IAddressCompanyApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/address-company/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var phone = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, phone);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/address-company/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateAddressCompanyCommand(
                idAddressCompany: id,
                cep: (string)body.cep,
                logradouro: (string)body.logradouro,
                complemento: (string)body.complemento,
                bairro: (string)body.bairro,
                localidade: (string)body.localidade,
                uf: (string)body.uf,
                ibge: (string)body.ibge,
                gia: (string)body.gia,
                number: (string)body.number,
                reference: (string)body.reference
            );

            var address = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, address);
        }

        [HttpDelete]
        [Route("api/address-company/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {

            var command = new DeleteAddressCompanyCommand(
                idAddressCompany: id
            );

            var address = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, address);
        }

    }
}

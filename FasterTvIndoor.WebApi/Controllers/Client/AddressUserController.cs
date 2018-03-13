using FasterTvIndoor.Domain.Client.Commands.AddressUserCommands;
using FasterTvIndoor.Domain.Client.Services;
using FasterTvIndoor.WebApi.Controllers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RedeFaster.WebApi.Controllers.Client
{
    public class AddressUserController : BaseController
    {
        private readonly IAddressUserApplicationService _service;

        public AddressUserController(IAddressUserApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/address-user/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var address = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, address);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/address-user/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateAddressUserCommand(
                idAddressUser: id,
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

        [HttpPost]
        //[Authorize]
        [Route("api/address-user/")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {

            var command = new CreateAddressUserCommand(
                cep: (string)body.cep,
                logradouro: (string)body.logradouro,
                complemento: (string)body.complemento,
                bairro: (string)body.bairro,
                localidade: (string)body.localidade,
                uf: (string)body.uf,
                ibge: (string)body.ibge,
                gia: (string)body.gia,
                number: (string)body.number,
                reference: (string)body.reference,
                idUser: (int)body.idUser
            );

            var address = _service.Create(command);
            return CreateResponse(HttpStatusCode.OK, address);
        }

        [HttpDelete]
        [Route("api/address-user/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {

            var command = new DeleteAddressUserCommand(
                idAddressUser: id
            );

            var address = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, address);
        }

    }
}

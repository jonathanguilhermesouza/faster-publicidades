using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    [Authorize(Roles = "Suporte,Master")]
    public class TypeEquipmentController : BaseController
    {
        
        private readonly ITypeEquipmentApplicationService _service;

        public TypeEquipmentController(ITypeEquipmentApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/type-equipment")]
        public Task<HttpResponseMessage> GetAll()
        {
            var equipment = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, equipment);
        }

        [HttpGet]
        [Route("api/type-equipment/range/{skip:int:min(0)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take = 12)
        {
            var equipment = _service.GetByRange(skip, take);
            return CreateResponse(HttpStatusCode.OK, equipment);
        }

        [HttpGet]
        [Route("api/type-equipment/count")]
        public Task<HttpResponseMessage> GetCount()
        {
            var countTypeEquipment = _service.GetCount();
            return CreateResponse(HttpStatusCode.OK, countTypeEquipment);
        }

        [HttpGet]
        [Route("api/type-equipment/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var equipment = _service.GetById(id);
            return CreateResponse(HttpStatusCode.Created, equipment);
        }

        [HttpPost]
        [Route("api/type-equipment")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateTypeEquipmentCommand(
                type: (string)body.type
            );

            var equipment = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, equipment);
        }

        [HttpDelete]
        [Route("api/type-equipment/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var command = new DeleteTypeEquipmentCommand(
                idTypeEquipment: id
            );

            var equipment = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, equipment);
        }

        [HttpPut]
        [Route("api/type-equipment/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateTypeEquipmentCommand(
                idTypeEquipment: id,
                type: (string)body.type
           );

            var equipment = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, equipment);

        }

    }
}

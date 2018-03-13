using FasterTvIndoor.Domain.FasterAdministration.Commands.EquipmentCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
   // [Authorize(Roles = "Suporte,Master")]
    public class EquipmentController : BaseController
    {
        
        private readonly IEquipmentApplicationService _service;

        public EquipmentController(IEquipmentApplicationService service)
        {
            _service = service;
        }       

        [HttpGet]
        //[Authorize]
        [Route("api/equipment/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var equipment = _service.GetById(id);            
            return CreateResponse(HttpStatusCode.Created, equipment);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/equipment/range/{skip:int:min(0)}/{status}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, string word, EStatusEquipment status, int take = 12)
        {
            var equipment = _service.GetByRange(skip, take, word, status);
            return CreateResponse(HttpStatusCode.OK, equipment);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/equipment/teste")]
        public Task<HttpResponseMessage> GetAllEquipmentControlLoan()
        {
            var equipment = _service.GetAllEquipmentControlLoan("Tv", EStatusEquipment.Emprestado, EStatusControlLoan.Vigente);
            return CreateResponse(HttpStatusCode.OK, equipment);
        }

        [HttpGet]
        [Route("api/equipment/count/{status}/{word}")]
        public Task<HttpResponseMessage> GetCount(string word, EStatusEquipment status)
        {
            var countEquipment = _service.GetCount(word,status);        
            return CreateResponse(HttpStatusCode.OK, countEquipment);
        }
       

        [HttpPost]
        //[Authorize]
        [Route("api/equipment/")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateEquipmentCommand(
                idTypeEquipment: (int)body.idTypeEquipment,
                description: (string)body.description,
                model: (string)body.model,
                serialNumber:(string)body.serialNumber,
                dateBuy: (DateTime)body.dateBuy,
                patrimony:(string)body.patrimony
            );

            var equipment = _service.Create(command);
            
            return CreateResponse(HttpStatusCode.Created, equipment);
        }


        [HttpDelete]
        [Route("api/equipment/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            //var company = _service.Delete(id);
            var command = new DeleteEquipmentCommand(
                idEquipment: id
            );

            var equipment = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, equipment);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/equipment/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateEquipmentCommand(
                idEquipment: id,
                idTypeEquipment: (int)body.idTypeEquipment,
                description: (string)body.description,
                model: (string)body.model,
                serialNumber: (string)body.serialNumber,
                dateBuy: (DateTime)body.dateBuy,
                patrimony: (string)body.patrimony,
                statusEquipment: (EStatusEquipment)body.statusEquipment
            );

            var equipment = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, equipment);
        }
    }
}

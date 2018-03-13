using FasterTvIndoor.Domain.FasterAdministration.Commands.SectorCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    [Authorize(Roles = "Suporte,Master")]
    public class SectorCompanyController : BaseController
    {
        
        private readonly ISectorCompanyApplicationService _service;
        public SectorCompanyController(ISectorCompanyApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/sector")]
        public Task<HttpResponseMessage> GetAll()
        {
            var sector = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, sector);
        }

        [HttpGet]
        [Route("api/sector/range/{skip:int:min(0)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take = 12)
        {
            var sector = _service.GetByRange(skip, take);
            return CreateResponse(HttpStatusCode.OK, sector);
        }

        [HttpGet]
        [Route("api/sector/count")]
        public Task<HttpResponseMessage> GetCount()
        {
            var countSector = _service.GetCount();
            return CreateResponse(HttpStatusCode.OK, countSector);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/sector")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateSectorCompanyCommand(
                sector: (string)body.sector
            );

            var sector = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, sector);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/sector/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateSectorCompanyCommand(
                idSectorCompany: id,
                sector: (string)body.sector
            );

            var sector = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, sector);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/sector/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var sector = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, sector);
        }
    }
}

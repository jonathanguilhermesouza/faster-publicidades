using FasterTvIndoor.Domain.FasterAdministration.Commands.CompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    //[Authorize(Roles = "Suporte,Master")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyApplicationService _service;

        public CompanyController(ICompanyApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/company/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var company = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, company);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/company/range/{skip:int:min(0)}/{status}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, EStatusCompany status, string word, int take = 12)
        {
            var company = _service.GetByRange(skip, take, word, status);
            return CreateResponse(HttpStatusCode.OK, company);
        }

        [HttpGet]
        [Route("api/company/count/{status}/{word}")]
        public Task<HttpResponseMessage> GetCount(EStatusCompany status, string word)
        {
            var countCompany = _service.GetCount(word, status);
            return CreateResponse(HttpStatusCode.OK, countCompany);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/company/")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateCompanyCommand(
                companyName: (string)body.companyName,
                fantasyName: (string)body.fantasyName,
                stateInscription: (string)body.stateInscription,
                cnpj: (string)body.cnpj,
                email: (string)body.email,
                classificationCompany: (EClassificationCompany)body.classificationCompany,
                sizeCompany:(ESizeCompany)body.sizeCompany,
                listAddressCompany: body.listAddressCompany.ToObject<List<AddressCompany>>(),
                listPhonesCompany: body.listPhonesCompany.ToObject<List<PhoneCompany>>()
            );

            var company = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, company);
        }


        [HttpDelete]
        [Route("api/company/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            //var company = _service.Delete(id);

            var command = new DeleteCompanyCommand(
                idCompany: id,
                statusCompany: EStatusCompany.Inativa
            );

            var company = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, company);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/company/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateCompanyCommand(
                idCompany: id,
                companyName: (string)body.companyName,
                fantasyName: (string)body.fantasyName,
                stateInscription: (string)body.stateInscription,
                cnpj: (string)body.cnpj,
                email: (string)body.email,
                statusCompany: (EStatusCompany)body.statusCompany,
                classificationCompany: (EClassificationCompany)body.classificationCompany,
                sizeCompany: (ESizeCompany)body.sizeCompany
            );

            var company = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, company);
        }
    }
}

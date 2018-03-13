using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.BackOffice.Commands.EmployeeCompany;
using FasterTvIndoor.Domain.BackOffice.Services;
using FasterTvIndoor.Domain.Client.Entities;
using FasterTvIndoor.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.BackOffice
{
    //[Authorize(Roles = "Administrador,Master,Suporte")]
    public class EmployeeCompanyController : BaseController
    {
        private readonly IEmployeeCompanyApplicationService _service;
        public EmployeeCompanyController(IEmployeeCompanyApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/employee/range/{skip:int:min(0)}/{status}/{word}")]
        public Task<HttpResponseMessage> GetByRange(int skip, EStatusUser status,string word)
        {
            var employee = _service.GetByRange(skip, word, status);
            return CreateResponse(HttpStatusCode.OK, employee);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/employee/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            var employee = _service.GetById(id);
            return CreateResponse(HttpStatusCode.OK, employee);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/employee/email/{email}")]
        public Task<HttpResponseMessage> GetByEmail(string email)
        {
            var employee = _service.GetByEmail(email);
            return CreateResponse(HttpStatusCode.OK, employee);
        }

        [HttpGet]
        [Route("api/employee/count/{status}/{word}")]
        public Task<HttpResponseMessage> GetCount(string word, EStatusUser status)
        {
            var countEmployee = _service.GetCount(word,status);
            return CreateResponse(HttpStatusCode.OK, countEmployee);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/employee/")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {

            var user = new User((string)body.user.email, 
                                (string)body.user.name, 
                                (string)body.user.lastName, 
                                (string)body.user.password, 
                                (string)body.user.nickName,
                                body.user.listAddressUser.ToObject<List<AddressUser>>(),
                                body.user.listPhoneUser.ToObject<List<PhoneUser>>());


            var command = new CreateEmployeeCompanyCommand(
                cpf: (string)body.cpf,           
                user: user,
                idSectorCompany: (int)body.idSectorCompany,
                idCompany: (int)body.idCompany
            );

            var employee = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, employee);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/employee/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateEmployeeCompanyCommand(
                idEmployeeCompany: id,    
                cpf: (string)body.cpf,
                idSectorCompany: (int)body.idSectorCompany
            );

            var employee = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, employee);
        }

        [HttpDelete]
        [Route("api/employee/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {

            var command = new DeleteEmployeeCompanyCommand(
                idEmployeeCompany: id
            );

            var employee = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, employee);
        }
    }
}

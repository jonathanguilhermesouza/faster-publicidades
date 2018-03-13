using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
{
    public class SizeCompanyController : BaseController
    {
        private readonly ISizeCompanyApplicationService _service;

        public SizeCompanyController(ISizeCompanyApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/size-company")]
        public Task<HttpResponseMessage> GetAll()
        {
            var size = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, size);
        }
    }
}

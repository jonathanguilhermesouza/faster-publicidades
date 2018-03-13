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
    public class StatusVideoController : BaseController
    {
        private readonly IStatusVideoApplicationService _service;

        public StatusVideoController(IStatusVideoApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/status-video")]
        public Task<HttpResponseMessage> GetAll()
        {
            var status = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, status);
        }
    }
}
